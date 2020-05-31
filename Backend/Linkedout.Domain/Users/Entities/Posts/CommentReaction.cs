using Linkedout.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Linkedout.Domain.Users.Entities.Posts
{
    public class CommentReaction : IEntity
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid ReactionId { get; set; }
        public string ReactorId { get; set; }

        [ForeignKey("ReactorId")]
        public virtual User Reactor { get; set; }
    }
}
