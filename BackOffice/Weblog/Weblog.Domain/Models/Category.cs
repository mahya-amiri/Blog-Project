using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Weblog.Domain.Models
{
    [Table("Categories")]

    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public List<Article> Articles { get; set; }

        public Category() 
        {
        }
    }
}
