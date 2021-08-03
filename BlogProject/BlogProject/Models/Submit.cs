using System.ComponentModel.DataAnnotations;

namespace blogProject.Models
{
    public class Submit
    {
        public int submitID { get; set; }
        public int commentID { get; set; }
        public int articleID { get; set; }

        public Comments Comments { get; set; }
        public Articles Articles { get; set; }
    }
}