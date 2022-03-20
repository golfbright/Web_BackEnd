using MediatR;
using TMSAPI.Models;

namespace TMSAPI.Commands.SaveAccountRolesCommand
{
    public class SaveAccountRolesCommand :IRequest<AccountRole>
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RoleId { get; set; }
    }
}
