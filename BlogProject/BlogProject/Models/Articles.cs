using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogProject.Models
{
    public class Articles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int articleID { get; set; }
        public string articleTitle { get; set; }
        public string articleCategory { get; set; }

        public ICollection<Submit> Submits { get; set; }
    }
}