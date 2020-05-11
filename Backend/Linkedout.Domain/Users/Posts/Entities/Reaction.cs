﻿using Linkedout.Domain.Users.Entities;
using Linkedout.Domain.Enums;

namespace Linkedout.Domain.Users.Posts.Entities
{
    public class Reaction
    {
        public int Id { get; set; }
        public string ReactorId { get; set; }
        public virtual User Reactor { get; set; }
        public ReactionType ReactionType { get; set; }
        public int ReactOnId { get; set; }
        public ReactOnType ReactOnType { get; set; }
    }
}
