using HotChocolate.AspNetCore.Authorization;
using Linkedout.Application.User.Queries;
using Linkedout.Application.User.ViewModels;
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

        // [Authorize]
        public async Task<List<UserViewModel>> GetAll() => await _mediator.Value.Send(new GetAllUsersQuery());

        // [Authorize]
        public async Task<UserViewModel> GetById(string id) => await _mediator.Value.Send(new GetUserByIdQuery { Id = id });
    }
}
