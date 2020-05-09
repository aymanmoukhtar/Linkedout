
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Linkedout.Application.Post.Queries.GetPostsByUserId
{
    using Linkedout.Domain.Interfaces.Repository;
    using Linkedout.Domain.ViewModels.Post;
    using Linkedout.Domain.Entities.Posts;
    using Linkedout.Domain.ViewModels.User;

    public class GetPostsByUserIdQuery : IRequest<List<PostViewModel>>
    {
        public string UserId { get; set; }
    }

    public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserIdQuery, List<PostViewModel>>
    {
        private readonly Lazy<IReadonlyRepository<Post>> _postReadonlyRepository;
        public GetPostsByUserIdQueryHandler(Lazy<IReadonlyRepository<Post>> postReadonlyRepository)
        {
            _postReadonlyRepository = postReadonlyRepository;
        }
        public Task<List<PostViewModel>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var posts = _postReadonlyRepository.Value.GetAll().Where(_ => _.CreatorId == request.UserId);
            var result = posts.Select(_ => new PostViewModel
            {
                Id = _.Id,
                CreatedAt = _.CreatedAt,
                Content = _.Content,
                ReactionsCount = _.ReactionsCount,
                Creator = new UserViewModel
                {
                    Id = _.Creator.Id,
                    FirstName = _.Creator.FirstName,
                },
            }).ToListAsync();

            return result;
        }
    }
}

