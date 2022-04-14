using MediatR;
using System;
using TMSAPI.Models;

namespace TMSAPI.Commands.TaskCommand
{
    public class SaveTaskListCommand: IRequest<TaskList>
    {
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
