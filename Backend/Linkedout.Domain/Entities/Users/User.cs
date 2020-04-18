using Linkedout.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Linkedout.Domain.Entities.Users
{
    public class User : IdentityUser, IEntity
    {
        public string FirstName { get; set; }
    }
}
