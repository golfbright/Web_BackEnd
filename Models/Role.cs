using System;
using System.Collections.Generic;

namespace TMSAPI.Models
{
    public partial class Role
    {
        public Role(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public void Update(string roleName)
        {
            RoleName = roleName;
        }
    }
}
