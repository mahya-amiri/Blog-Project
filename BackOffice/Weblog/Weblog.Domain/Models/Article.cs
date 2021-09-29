using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Weblog.Domain.Models
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        [MaxLength(500)]
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Status { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Article()
        {

        }

        public Article(string title, string body, string shortDescription, string image, bool status, User user, Category category)
        {
            checkValidation(title, body, shortDescription);


            Title = title;
            Body = body;
            ShortDescription = shortDescription;
            Image = image;
            CreatedAt = DateTime.Now;
            Status = status;
            UserId = user.Id;
            CategoryId = category.Id;
        }

        public static void checkValidation(string title, string body, string shortDescription)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new Exception("عنوان مقاله را وارد کنید");
            }

            if (title.Length >= 200)
            {
                throw new Exception("عنوان مقاله طولانی می باشد");
            }
            if (string.IsNullOrEmpty(shortDescription))
            {
                throw new Exception("توضیحات مقاله را وارد کنید");
            }

            if (shortDescription.Length >= 500)
            {
                throw new Exception("توضیحات مقاله طولانی می باشد");
            }
            if (string.IsNullOrEmpty(body))
            {
                throw new Exception("مقاله را وارد کنید");
            }
        }
    }
}