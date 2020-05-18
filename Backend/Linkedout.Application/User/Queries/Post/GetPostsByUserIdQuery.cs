using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Linkedout.Application.User.ViewModels;
using Linkedout.Domain.Interfaces.Repository;

namespace Linkedout.Application.User.Queries.Post
{
    using Linkedout.Domain.Users.Posts.Entities;

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
        public async Task<List<PostViewModel>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var posts = _postReadonlyRepository.Value.GetAll().Where(_ => _.CreatorId == request.UserId);
            var result = await posts.Select(_ => new PostViewModel
            {
                Id = _.Id,
                CreatedAt = _.CreatedAt,
                Content = _.Content,
                Reactions = _.Reactions.Count(),
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

