using Linkedout.Application.Post.Commands.CreatePost;
using Linkedout.Domain.Entities.Posts;
using Linkedout.Domain.ViewModels.Post;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
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
