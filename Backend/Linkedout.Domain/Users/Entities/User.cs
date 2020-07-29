using Linkedout.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Linkedout.Domain.Users.Entities
{
    public class User : IdentityUser, IEntity
    {
        public string FirstName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string SmallProfilePictureUrl { get; set; }
    }
}
