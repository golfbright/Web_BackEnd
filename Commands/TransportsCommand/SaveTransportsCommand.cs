using MediatR;
using TMSAPI.Models;

namespace TMSAPI.Commands.TransportsCommand
{
    public class SaveTransportsCommand: IRequest<Transports>
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int AddressId { get; set; }
        public int CarId { get; set; }
    }
}
