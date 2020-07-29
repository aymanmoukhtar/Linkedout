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
    public class RequestConnectionCommand : IRequest<Connection>
    {
        public string UserId { get; set; }
        public string ConnectorId { get; set; }
    }

    public class RequestConnectionCommandHandler : IRequestHandler<RequestConnectionCommand, Connection>
    {
        private readonly Lazy<IRepository<Connection>> _connectionRepository;
        public RequestConnectionCommandHandler(Lazy<IRepository<Connection>> connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }
        public async Task<Connection> Handle(RequestConnectionCommand request, CancellationToken cancellationToken)
        {
            var newConnection = new Connection
            {
                ConnectorId = request.ConnectorId,
                UserId = request.UserId
            };
            await _connectionRepository.Value.Create(newConnection);
            await _connectionRepository.Value.UnitOfWork.CommitAsync();
            return newConnection;
        }
    }
}
