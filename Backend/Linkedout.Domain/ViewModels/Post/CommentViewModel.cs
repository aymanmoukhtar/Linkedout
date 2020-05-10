using Linkedout.Domain.ViewModels.User;
using System;

namespace Linkedout.Domain.ViewModels.Post
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public UserViewModel Creator { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
