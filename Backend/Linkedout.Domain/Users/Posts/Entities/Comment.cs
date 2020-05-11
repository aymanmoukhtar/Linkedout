using Linkedout.Domain.Users.Entities;
using Linkedout.Domain.Interfaces;
using System;

namespace Linkedout.Domain.Users.Posts.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Reactions { get; set; }
        public string CreatorId { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual User Creator { get; set; }
        public virtual Post Post { get; set; }
    }
}
