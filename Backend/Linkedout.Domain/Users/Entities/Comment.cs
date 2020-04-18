using System;
using System.Collections.Generic;
using System.Text;

namespace Linkedout.Domain.Users.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public string CreatorId { get; set; }
        public int PostId { get; set; }
        public virtual User Creator { get; set; }
        public virtual Post Post { get; set; }
        public virtual List<User> Likers { get; set; }
    }
}
