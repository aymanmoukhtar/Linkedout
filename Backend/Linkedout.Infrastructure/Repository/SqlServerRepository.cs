using Linkedout.Domain.Interfaces;
using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Infrastructure.Repository.SqlServerContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Linkedout.Infrastructure.Repository
{
    public class SqlServerRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        private readonly DbSet<TEntity> _set;

        public SqlServerRepository(IUnitOfWork unitOfWork, LinkedoutEntities context)
        {
            UnitOfWork = unitOfWork;
            _set = context.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await _set.AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await Task.FromResult(_set.Remove(entity));
        }

        public IQueryable<TEntity> GetAll() => _set;

        public async Task<TEntity> GetById(string id) => await _set.FindAsync(id);

        public void Update(TEntity entity)
        {
            var attached = _set.Attach(entity);
            attached.State = EntityState.Modified;
        }
    }
}
