
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linkedout.Application.Post.Commands.CreatePost
{
    using Linkedout.Domain.Entities.Posts;
    using Linkedout.Domain.Interfaces.Repository;
    using Linkedout.Domain.ViewModels.Post;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreatePostCommand : IRequest<Post>
    {
        public CreatePostViewModel Post { get; set; }
    }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
    {
        private readonly Lazy<IRepository<Post>> _postRepository;
        public CreatePostCommandHandler(Lazy<IRepository<Post>> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Content = request.Post.Content,
                CreatedAt = request.Post.CreatedAt,
                CreatorId = request.Post.CreatorId
            };

            await _postRepository.Value.Create(newPost);
            await _postRepository.Value.UnitOfWork.CommitAsync();
            return newPost;
        }
    }
}
