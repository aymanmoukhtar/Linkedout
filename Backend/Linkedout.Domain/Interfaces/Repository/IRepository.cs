using System.Linq;
using System.Threading.Tasks;

namespace Linkedout.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IUnitOfWork UnitOfWork { get; }
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(string id);
        Task Create(TEntity entity);
        void Update(TEntity entity);
        Task Delete(TEntity id);
    }
}
