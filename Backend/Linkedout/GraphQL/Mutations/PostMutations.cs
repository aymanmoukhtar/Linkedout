using Linkedout.Application.User.Commands.Post;
using Linkedout.Application.User.ViewModels;
using Linkedout.Domain.Users.Posts.Entities;
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

        public async Task<Post> CreatePost(CreatePostViewModel post) => await _mediator.Value.Send(new CreatePostCommand { Post = post });
    }
}
