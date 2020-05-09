using Linkedout.Domain.Entities;
using Linkedout.Domain.Entities.Posts;
using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Infrastructure.Repository.SqlServerContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linkedout.Infrastructure.Repository
{
    public class CommentRepository : SqlServerRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork,
          LinkedoutEntities context) : base(unitOfWork, context) { }
    }
}
