using Linkedout.Application.User.Commands.Connections;
using Linkedout.Domain.Users.Entities.Connections;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.GraphQL.Mutations
{
    public class ConnectionMutations
    {
        private readonly Lazy<IMediator> _mediator;

        public ConnectionMutations(
            Lazy<IMediator> mediator
            )
        {
            _mediator = mediator;
        }

        public async Task<Connection> CreateConnection(CreateConnectionCommand request) => await _mediator.Value.Send(request);
        public async Task RemoveConnection(RemoveConnectionCommand request) => await _mediator.Value.Send(request);

    }
}
