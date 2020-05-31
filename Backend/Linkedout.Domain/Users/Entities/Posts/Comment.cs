using Linkedout.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Linkedout.Domain.Users.Entities.Posts
{
    public class Comment : IEntity
    {
        public Comment()
        {
            Reactions = new HashSet<CommentReaction>();
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
        public string CreatorId { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public virtual ICollection<CommentReaction> Reactions { get; set; }
    }
}
