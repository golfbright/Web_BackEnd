using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Commands.AddressCommand
{
    public class SaveAddressCommandHandler : IRequestHandler<SaveAddressCommand, Address>
    {
        private readonly IAddressRepository _addressRepository;
        public SaveAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Address> Handle(SaveAddressCommand cmd, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetAddressById(cmd.Id);
            if (address == null)
            {
                address = AddNewAddress(cmd);
                _addressRepository.Add(address);
            }
            else
            {
                UpdateAddress(address, cmd);
                _addressRepository.Update(address);
            }
            await _addressRepository.SaveChangesAsync();
            return address;
            //return await _customerRepository.AddAsync(request.Customers);
        }
        private Address AddNewAddress(SaveAddressCommand cmd)
        {
            return new Address(cmd.NamePlace, cmd.Gps, cmd.AddressNumber, cmd.District, cmd.Country, cmd.Street, cmd.ZipCode, cmd.Province);
        }
        private void UpdateAddress(Address address, SaveAddressCommand cmd)
        {
            address.Update(cmd.NamePlace, cmd.Gps, cmd.AddressNumber, cmd.District, cmd.Country, cmd.Street, cmd.ZipCode, cmd.Province);
        }
    }
}
