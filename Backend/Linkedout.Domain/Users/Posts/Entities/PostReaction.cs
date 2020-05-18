using Linkedout.Domain.Users.Entities;

namespace Linkedout.Domain.Users.Posts.Entities
{
    public class PostReaction
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ReactionId { get; set; }
        public int ReactorId { get; set; }
        public User Reactor { get; set; }

    }
}
