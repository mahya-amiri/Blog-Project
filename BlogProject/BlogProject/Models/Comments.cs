using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace blogProject.Models
{
    public class Comments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int commentID { get; set; }
        public string commentCategory { get; set; }

        public ICollection<Submit> Submits { get; set; }
    }
}