using Linkedout.Domain.Users.Entities;
using System.Threading.Tasks;

namespace Linkedout.Domain.Interfaces.Services.Identity
{
    public interface IIdentityService
    {
        Task<string> LoginAsync(string userName, string password);
        Task<User> CreateAsync(User user, string password);
    }
}
