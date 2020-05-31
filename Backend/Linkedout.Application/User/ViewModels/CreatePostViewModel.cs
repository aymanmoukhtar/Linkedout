using System;

namespace Linkedout.Application.User.ViewModels
{
    public class CreatePostViewModel
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatorId { get; set; }
    }
}
