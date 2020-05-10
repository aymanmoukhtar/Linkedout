using Linkedout.Domain.Entities.Users;
using Linkedout.Domain.Interfaces;
using System;
using System.Linq;

namespace Linkedout.Domain.Entities.Posts
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ReactionsCount { get; set; }
        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual IQueryable<Comment> Comments { get; set; }
    }
}
