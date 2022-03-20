using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TMSAPI.Models;
using TMSAPI.Repositories;

namespace TMSAPI.Commands.TransportsCommand
{
    public class SaveTransportsCommandHandler : IRequestHandler<SaveTransportsCommand, Transports>
    {
        private readonly ITransportsRepository _transprotRepository;
        public SaveTransportsCommandHandler(ITransportsRepository transportsRepository)
        {
            _transprotRepository = transportsRepository;
        }
        public async Task<Transports> Handle(SaveTransportsCommand cmd, CancellationToken cancellationToken)
        {
            var transport = AddNewTransports(cmd);
            _transprotRepository.Add(transport);
            await _transprotRepository.SaveChangesAsync();
            return transport;
            //return await _customerRepository.AddAsync(request.Customers);
        }
        private Transports AddNewTransports(SaveTransportsCommand cmd)
        {
            return new Transports(cmd.Id, cmd.CarId,cmd.TaskId,cmd.AddressId);
        }
    }
}
