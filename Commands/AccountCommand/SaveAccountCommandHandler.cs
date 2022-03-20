using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Commands.AccountCommand
{
    public class SaveAccountCommandHandler : IRequestHandler<SaveAccountCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;
        public SaveAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Account> Handle(SaveAccountCommand cmd, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountById(cmd.Id);
            
            if(account == null)
            {
                account = AddNewAccount(cmd);
                _accountRepository.Add(account);
            }
            else
            {
                UpdateAccount(account, cmd);
                _accountRepository.Update(account);
            }

            if (cmd.RoleIds != null)
            {
                var existRoleId = account.AccountRoles.Select(y => y.RoleId).ToList();
                var addRoleId = cmd.RoleIds?.Where(x => !existRoleId.Contains(x)).ToList();

                foreach (var roleId in addRoleId)
                {
                    var accountRole = new AccountRole(roleId);
                    account.AddAccountRole(accountRole);
                }

                var delRoleId = existRoleId.Where(x => !cmd.RoleIds.Contains(x)).ToList();
                var deleRoles = account.AccountRoles.Where(x => delRoleId.Contains(x.RoleId)).ToList();
                foreach (var delRole in deleRoles)
                {
                    account.DeleteAccountRole(delRole);
                }
            }

            

            await _accountRepository.SaveChangesAsync();
            return account;
            
        }
        private Account AddNewAccount(SaveAccountCommand cmd)
        {
            return new Account(cmd.EmployeeNo, cmd.Password, cmd.Status, cmd.FirstName, cmd.LastName, cmd.Tel, cmd.CardId, cmd.DriverLicense, cmd.ImageProfilePath);
        }

        private void UpdateAccount(Account account,SaveAccountCommand cmd)
        {


            account.Update(cmd.EmployeeNo,cmd.Password,cmd.Status, cmd.FirstName, cmd.LastName, cmd.Tel, cmd.CardId, cmd.DriverLicense, cmd.ImageProfilePath);
        }
    }
}
