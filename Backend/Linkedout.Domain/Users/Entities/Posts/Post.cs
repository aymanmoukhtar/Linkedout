using Linkedout.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Linkedout.Domain.Users.Entities.Posts
{
    public class Post : IEntity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Reactions = new HashSet<PostReaction>();
        }
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostReaction> Reactions { get; set; }
    }
}
