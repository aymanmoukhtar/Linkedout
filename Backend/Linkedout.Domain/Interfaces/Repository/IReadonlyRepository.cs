using System.Linq;
using System.Threading.Tasks;

namespace Linkedout.Domain.Interfaces.Repository
{
    public interface IReadonlyRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(string id);
    }
}
