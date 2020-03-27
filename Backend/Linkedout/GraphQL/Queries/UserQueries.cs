using Linkedout.Application.User.Queries.GetAllUsersQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.GraphQL.Queries
{
    public class UserQueries
    {
        private readonly Lazy<IMediator> _mediator;

        public UserQueries(
            Lazy<IMediator> mediator
            )
        {
            _mediator = mediator;
        }

        public async Task<List<GetAllUsersOutput>> GetAll() => await _mediator.Value.Send(new GetAllUsersQuery());
    }
}
