using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Commands.SaveAccountRolesCommand
{
    public class SaveAccountRolesCommandHandler : IRequestHandler<SaveAccountRolesCommand, AccountRole>
    {
        private readonly IAccountRoleRepository _accountRolesRepository;
        public SaveAccountRolesCommandHandler(IAccountRoleRepository accountRolesRepository)
        {
            _accountRolesRepository = accountRolesRepository;
        }
        public async Task<AccountRole> Handle(SaveAccountRolesCommand cmd, CancellationToken cancellationToken)
        {
            var accountRoles = AddNewAccountRoles(cmd);
            _accountRolesRepository.Add(accountRoles);
            await _accountRolesRepository.SaveChangesAsync();
            return accountRoles;
            //return await _customerRepository.AddAsync(request.Customers);
        }
        private AccountRole AddNewAccountRoles(SaveAccountRolesCommand cmd)
        {
            return new AccountRole(cmd.Id,cmd.AccountId,cmd.RoleId);
        }
    }
}
