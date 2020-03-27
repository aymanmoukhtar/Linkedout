using Linkedout.Domain.Users.Entities;
using System.Threading.Tasks;

namespace Linkedout.Infrastructure.Services.Identity
{
    public interface IIdentityService
    {
        Task<UserTokenViewModel> LoginAsync(UserLoginInput input);
        Task<User> CreateAsync(CreateUserInput input);
    }
}
