using Linkedout.Domain.Interfaces;
using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Infrastructure.Repository.SqlServerContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Linkedout.Infrastructure.Repository
{
    public class SqlServerReadonlyRepository<TEntity> : IReadonlyRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _set;

        public SqlServerReadonlyRepository(LinkedoutEntities context)
        {
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _set = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() => _set;

        public async Task<TEntity> GetById(string id) => await _set.FindAsync(id);
    }
}
