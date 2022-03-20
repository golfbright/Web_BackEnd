using MediatR;
using TMSAPI.Models;

namespace TMSAPI.Commands.VehicleCommand
{
    public class SaveVehicleCommand : IRequest<Vehicle>
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string VehicleBrand { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleStatus { get; set; }
    }
}
