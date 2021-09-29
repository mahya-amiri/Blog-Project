using System;
using Weblog.Domain.Models;

namespace Weblog.ViewModels
{
    public class ArticleVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public int? CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ArticleVM(int id, string title, string body, string shortDescription,string image,
            bool status, int? categoryId, int userId, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            Title = title;
            Body = body;
            ShortDescription = shortDescription;
            Image = image;
            Status = status;
            CategoryId = categoryId;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
