using MediatR;
using TMSAPI.Models;

namespace TMSAPI.Commands.AddressCommand
{
    public class SaveAddressCommand : IRequest<Address>
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
