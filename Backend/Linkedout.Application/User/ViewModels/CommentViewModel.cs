using System;

namespace Linkedout.Application.User.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public UserViewModel Creator { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
