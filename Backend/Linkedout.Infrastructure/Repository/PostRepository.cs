using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Domain.Users.Posts.Entities;
using Linkedout.Infrastructure.Repository.SqlServerContext;


namespace Linkedout.Infrastructure.Repository
{
    public class PostRepository : SqlServerRepository<Post>, IPostRepository
    {

        public PostRepository(IUnitOfWork unitOfWork,
           LinkedoutEntities context) : base(unitOfWork, context) { }
    }
}
