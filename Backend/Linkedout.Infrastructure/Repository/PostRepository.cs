using Linkedout.Domain.Entities;
using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Infrastructure.Repository.SqlServerContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Linkedout.Infrastructure.Repository
{
    public class PostRepository : SqlServerRepository<Post>, IPostRepository
    {

        public PostRepository(IUnitOfWork unitOfWork,
           LinkedoutEntities context) : base(unitOfWork, context) { }
    }
}
