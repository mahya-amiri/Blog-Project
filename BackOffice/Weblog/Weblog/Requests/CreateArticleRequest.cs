using Microsoft.AspNetCore.Http;
using Weblog.Domain.Models;

namespace Weblog.Controllers
{
    public class CreateArticleRequest
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ShortDescription { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
        public string Token { get; set; }
        public bool Status { get; set; }

        public CreateArticleRequest()
        {

        }
        public CreateArticleRequest(string title, string body, string shortDescription,
            IFormFile image,int categoryId, bool status, string token)
        {
            Title = title;
            Body = body;
            ShortDescription = shortDescription;
            Image = image;
            CategoryId = categoryId;
            Status = status;
            Token = token;
        }
    }
}