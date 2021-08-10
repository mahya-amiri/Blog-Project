using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
