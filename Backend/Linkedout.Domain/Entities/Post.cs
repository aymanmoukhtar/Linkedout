using Linkedout.Domain.Entities.Users;
using Linkedout.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linkedout.Domain.Entities
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public int CommentsCount { get; set; }
        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual List<User> Likers { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
