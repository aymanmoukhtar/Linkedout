using System;
using System.Collections.Generic;
using System.Text;

namespace Linkedout.Domain.ViewModels.Post
{
    public class CreatePostViewModel
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatorId { get; set; }
    }
}
