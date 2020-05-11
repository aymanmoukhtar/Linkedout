using System;
using System.Collections.Generic;

namespace Linkedout.Application.User.ViewModels
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
