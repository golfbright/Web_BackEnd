using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Commands.RoleCommand
{
    public class SaveRoleCommandHandler : IRequestHandler<SaveRoleCommand, Role>
    {
        private readonly IRoleRepository _roleRepository;
        public SaveRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> Handle(SaveRoleCommand cmd, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRoleById(cmd.Id);

            if (role == null)
            {
                role = AddNewRole(cmd);
            _roleRepository.Add(role);
            }
            else
            {
                UpdateRole(role, cmd);
                _roleRepository.Update(role);
            }
            await _roleRepository.SaveChangesAsync();
            return role;
            //return await _customerRepository.AddAsync(request.Customers);
        }

        private void UpdateRole(Role role, SaveRoleCommand cmd)
        {
            role.Update(cmd.RoleName);
        }

        private Role AddNewRole(SaveRoleCommand cmd)
        {
            return new Role (cmd.Id, cmd.RoleName);
        }
    }
}
