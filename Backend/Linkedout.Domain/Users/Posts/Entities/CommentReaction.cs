using Linkedout.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linkedout.Domain.Users.Posts.Entities
{
    public class CommentReaction
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ReactionId { get; set; }
        public int ReactorId { get; set; }
        public virtual User Reactor { get; set; }
    }
}
