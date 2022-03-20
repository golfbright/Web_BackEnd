using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Commands.VehicleCommand
{
    public class SaveVehicleCommandHandler : IRequestHandler<SaveVehicleCommand, Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepository;
        public SaveVehicleCommandHandler(IVehicleRepository VehicleRepository)
        {
            _vehicleRepository = VehicleRepository;
        }
        public async Task<Vehicle> Handle(SaveVehicleCommand cmd, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleById(cmd.Id);
            if (vehicle == null)
            {
                vehicle = AddNewVehicle(cmd);
                _vehicleRepository.Add(vehicle);
            }
            else
            {
                UpdateVehicle(vehicle, cmd);
                _vehicleRepository.Update(vehicle);
            }
            await _vehicleRepository.SaveChangesAsync();
            return vehicle;
            //return await _customerRepository.AddAsync(request.Customers);
        }
        private Vehicle AddNewVehicle(SaveVehicleCommand cmd)
        {
            return new Vehicle(cmd.VehicleType, cmd.VehicleBrand, cmd.VehiclePlate, cmd.VehicleStatus);
        }

        private void UpdateVehicle(Vehicle vehicle, SaveVehicleCommand cmd)
        {
            vehicle.Update(cmd.VehicleType, cmd.VehicleBrand, cmd.VehiclePlate, cmd.VehicleStatus);
        }
    }
}