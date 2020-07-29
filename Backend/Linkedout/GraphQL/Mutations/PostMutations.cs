using HotChocolate.AspNetCore.Authorization;
using Linkedout.Application.User.Commands.Post;
using Linkedout.Application.User.ViewModels;
using Linkedout.Domain.Users.Entities.Posts;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.GraphQL.Mutations
{
    public class PostMutations
    {
        private readonly Lazy<IMediator> _mediator;

        public PostMutations(
            Lazy<IMediator> mediator
            )
        {
            _mediator = mediator;
        }
        [Authorize]
        public async Task<Post> CreatePost(CreatePostViewModel post) => await _mediator.Value.Send(new CreatePostCommand { Post = post });
    }
}
