using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Domain.Users.Entities.Connections;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Linkedout.Application.User.Commands.Connections
{
    public class AcceptConnectionCommand : IRequest
    {
        public string ConnectionId { get; set; }

    }
    public class AcceptConnectionCommandHandler : IRequestHandler<AcceptConnectionCommand>
    {
        private readonly Lazy<IRepository<Connection>> _connectionRepository;
        public AcceptConnectionCommandHandler(Lazy<IRepository<Connection>> connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }
        public async Task<Unit> Handle(AcceptConnectionCommand request, CancellationToken cancellationToken)
        {
            var connection = await _connectionRepository.Value.GetById(request.ConnectionId);
            connection.IsAccepted = true;
            _connectionRepository.Value.Update(connection);
            await _connectionRepository.Value.UnitOfWork.CommitAsync();
            return Unit.Value;
        }


    }
}
