

using Linkedout.Domain.ViewModels.User;
using System;
using System.Collections.Generic;

namespace Linkedout.Domain.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ReactionsCount { get; set; }
        public UserViewModel Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
