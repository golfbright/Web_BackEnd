using System;
using System.Collections.Generic;

namespace TMSAPI.Models
{
    public partial class AccountRole
    {
        public AccountRole( int roleId)
        {
            RoleId = roleId;
        }
        public AccountRole(int id, int accountId, int roleId)
        {
            Id = id;
            AccountId = accountId;
            RoleId = roleId;
        }
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RoleId { get; set; }
    }
}
