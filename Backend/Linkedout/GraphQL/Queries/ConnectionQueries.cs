using Linkedout.Application.User.Queries.Connections;
using Linkedout.Application.User.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.GraphQL.Queries
{
    public class ConnectionQueries
    {
        private readonly Lazy<IMediator> _mediator;

        public ConnectionQueries(
            Lazy<IMediator> mediator
            )
        {
            _mediator = mediator;
        }

        public async Task<List<ConnectionViewModel>> GetAllConnectionsByUserId(GetAllConnectionsByUserIdQuery request) => await _mediator.Value.Send(request);
    }
}
