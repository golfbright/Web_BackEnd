using System;
using System.Collections.Generic;

namespace TMSAPI.Models
{
    public partial class Account
    {
        public Account()
        {
            _accountRoles = new List<AccountRole>();
        }
        public Account(string employeeNo, string password, string status, string firstName, string lastName, string tel, string cardId, string driverLicense, string imageProfilePath) : this()
        {
            EmployeeNo = employeeNo;
            Password = password;
            Status = status;
            FirstName = firstName;
            LastName = lastName;
            Tel = tel;
            CardId = cardId;
            DriverLicense = driverLicense;
            ImageProfilePath = imageProfilePath;
        }

        public void Update(string employeeNo, string password, string status, string firstName, string lastName, string tel, string cardId, string driverLicense, string imageProfilePath)
        {
            
            EmployeeNo = employeeNo;
            Password = password;
            Status = status;
            FirstName = firstName;
            LastName = lastName;
            Tel = tel;
            CardId = cardId;
            DriverLicense = driverLicense;
            ImageProfilePath = imageProfilePath;
        }

        public int Id { get; private set; }
        public string EmployeeNo { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string CardId { get; set; }
        public string DriverLicense { get; set; }
        public string ImageProfilePath { get; set; }

        public IReadOnlyCollection<AccountRole> AccountRoles => _accountRoles;
        private List<AccountRole> _accountRoles;

        public void AddAccountRole(AccountRole accountRole)
        {
            _accountRoles.Add(accountRole);
        }
        public void DeleteAccountRole(AccountRole accountRole)
        { 
            _accountRoles.Remove(accountRole);
        }
        public void DeleteAllRole()
        {
            _accountRoles.Clear();
        }
    }
   
}
