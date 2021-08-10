using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class Comment
    {
        public int Id { set; get; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string Body { get; set; }
    }
}
