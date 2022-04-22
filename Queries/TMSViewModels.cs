using System;
using System.Collections.Generic;

namespace TMSAPI.Queries
{
    public class AccountViewModel
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
        public List<AccountRoleViewModel> AccountRoles { get; set; }
    }

    public class AccountRoleViewModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccountId { get; set; }
        public string RoleName { get; set; }
    }

    public class TaskListViewModel
    {
        public int Id { get; set; }
        public string TaskNumber { get; set; }
        public string TaskDetail { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskFinishDate { get; set; }
        public string TaskStatus { get; set; }
        public int AddressId { get; set; }
        public int VehicleId { get; set; }
        public string NamePlace { get; set; }
        public string Gps { get; set; }
        public string AddressNumber { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string VehicleType { get; set; }
        public string VehicleBrand { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleStatus { get; set; }
        public int AccountId { get; set; }

        //public List<TransportViewModel> Transport { get; set; }
    }
    public class TransportViewModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int AddressId { get; set; }
        public int CarId { get; set; }
    }
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string VehicleBrand { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleStatus { get; set; }
    }
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string NamePlace { get; set; }
        public string Gps { get; set; }
        public string AddressNumber { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
    }
}
