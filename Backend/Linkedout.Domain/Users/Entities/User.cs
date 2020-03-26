using Linkedout.Domain.Interfaces;

namespace Linkedout.Domain.Users.Entities
{
    public class User : IEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
    }
}
