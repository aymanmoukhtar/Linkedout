using HotChocolate.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<Connection> RequestConnection(RequestConnectionCommand request) => await _mediator.Value.Send(request);
        [Authorize]
        public async Task RemoveConnection(RemoveConnectionCommand request) => await _mediator.Value.Send(request);
        [Authorize]
        public async Task AcceptConnection(AcceptConnectionCommand request) => await _mediator.Value.Send(request);

    }
}
