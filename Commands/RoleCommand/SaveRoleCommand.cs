using MediatR;
using TMSAPI.Models;

namespace TMSAPI.Commands.RoleCommand
{
    public class SaveRoleCommand: IRequest<Role>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
