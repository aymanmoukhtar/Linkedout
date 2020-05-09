using Linkedout.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linkedout.Domain.ViewModels.Post
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public UserViewModel Creator { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
