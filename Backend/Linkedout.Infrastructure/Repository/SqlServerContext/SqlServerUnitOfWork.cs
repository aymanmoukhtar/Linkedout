using Linkedout.Domain.Interfaces.Repository;
using System.Threading.Tasks;

namespace Linkedout.Infrastructure.Repository.SqlServerContext
{
    public class SqlServerUnitOfWork : IUnitOfWork
    {
        private readonly LinkedoutEntities _context;
        public SqlServerUnitOfWork(LinkedoutEntities context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
