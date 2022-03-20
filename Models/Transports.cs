using System;
using System.Collections.Generic;

namespace TMSAPI.Models
{
    public partial class Transports
    {
        public Transports(int id, int carId, int taskId, int addressId)
        {
            Id = id;
            CarId = carId;
            TaskId = taskId;
            AddressId = addressId;
        }

        public int Id { get; set; }
        public int TaskId { get; set; }
        public int AddressId { get; set; }
        public int CarId { get; set; }
    }
}
