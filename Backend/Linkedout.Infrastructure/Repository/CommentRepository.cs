using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Domain.Users.Posts.Entities;
using Linkedout.Infrastructure.Repository.SqlServerContext;


namespace Linkedout.Infrastructure.Repository
{
    public class CommentRepository : SqlServerRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork,
          LinkedoutEntities context) : base(unitOfWork, context) { }
    }
}
