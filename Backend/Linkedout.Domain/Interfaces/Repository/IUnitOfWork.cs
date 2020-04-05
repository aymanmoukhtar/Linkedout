using System.Threading.Tasks;

namespace Linkedout.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
