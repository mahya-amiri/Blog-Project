using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public List<Category> PostCategory { get; set; }
        public List<Comment> PostComment { get; set; }
    }
}
