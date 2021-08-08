using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentCategory { get; set; }
        public string CommentBody { get; set; }
    }
}
