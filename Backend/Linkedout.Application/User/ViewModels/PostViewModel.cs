using System;
using System.Collections.Generic;

namespace Linkedout.Application.User.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Reactions { get; set; }
        public UserViewModel Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
