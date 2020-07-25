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
    public class RemoveConnectionCommand : IRequest
    {
        public string ConnectionId { get; set; }
    }

    public class RemoveConnectionCommandHandler : IRequestHandler<RemoveConnectionCommand>
    {
        private readonly Lazy<IRepository<Connection>> _connectionRepository;
        public RemoveConnectionCommandHandler(Lazy<IRepository<Connection>> connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }
        public async Task<Unit> Handle(RemoveConnectionCommand request, CancellationToken cancellationToken)
        {
            var connection = await _connectionRepository.Value.GetById(request.ConnectionId);
            connection.IsRemoved = true;
            _connectionRepository.Value.Update(connection);
            await _connectionRepository.Value.UnitOfWork.CommitAsync();
            return Unit.Value;
        }


    }
}
