using System.Collections.Generic;
using System.Linq;
using MediatR;
using TMSAPI.Models;

namespace TMSAPI.Commands.AccountCommand
{
    public class SaveAccountCommand : IRequest<Account>
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string CardId { get; set; }
        public string DriverLicense { get; set; }
        public string ImageProfilePath { get; set; }
        public List<int> RoleIds { get; set; }
    }

    public class AccountRoleCommand
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RoleId { get; set; }
    }
}
