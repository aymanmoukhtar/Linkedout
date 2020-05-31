using HotChocolate.AspNetCore.Authorization;
using Linkedout.Application.User.Queries.Post;
using Linkedout.Application.User.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.GraphQL.Queries
{
    public class PostQueries
    {
        private readonly Lazy<IMediator> _mediator;

        public PostQueries(
            Lazy<IMediator> mediator
            )
        {
            _mediator = mediator;
        }
        [Authorize]
        public async Task<List<PostViewModel>> GetPostsByUserId(string userId) => await _mediator
            .Value.Send(new GetPostsByUserIdQuery { UserId = userId });
    }
}
