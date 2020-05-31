using Linkedout.Domain.Interfaces;
using System;

namespace Linkedout.Domain.Users.Entities.Posts
{
    public class Reaction : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
