using Linkedout.Domain.Users.Entities;
using Linkedout.Domain.ViewModels.User;
using System.Threading.Tasks;

namespace Linkedout.Domain.Interfaces.Services.Identity
{
    public interface IIdentityService
    {
        Task<UserTokenViewModel> LoginAsync(UserLoginInput input);
        Task<User> CreateAsync(CreateUserInput input);
    }
}
