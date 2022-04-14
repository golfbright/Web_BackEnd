using System;


namespace TMSAPI.Models
{
    public partial class TaskList
    {
        public TaskList(string taskDetail, string taskNumber, DateTime taskStartDate, DateTime taskFinishDate, string taskStatus, int addressId, int vehicleId,int accountId)
        {
            TaskDetail = taskDetail;
            TaskNumber = taskNumber;
            TaskDate = DateTime.Now;
            TaskStartDate = taskStartDate;
            TaskFinishDate = taskFinishDate;
            TaskStatus = taskStatus;
            AddressId = addressId;
            VehicleId = vehicleId;
            AccountId = accountId;
        }

        public void Update(string taskDetail, string taskNumber, DateTime taskStartDate, DateTime taskFinishDate, string taskStatus, int addressId, int vehicleId, int accountId)
        {
            TaskDetail = taskDetail;
            TaskNumber = taskNumber;
            TaskDate = DateTime.Now;
            TaskStartDate = taskStartDate;
            TaskFinishDate = taskFinishDate;
            TaskStatus = taskStatus;
            AddressId = addressId;
            VehicleId = vehicleId;
            AccountId = accountId;
        }

        public int Id { get; set; }
        public string TaskDetail { get; set; }
        public string TaskNumber { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskFinishDate { get; set; }
        public string TaskStatus { get; set; }
        public int AddressId { get; set; }
        public int VehicleId { get; set; }
        public int AccountId { get; set; }
    }
}
