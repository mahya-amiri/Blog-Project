using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weblog.Requests
{
    public class UploadImageRequest
    {
        public string Body { get; set; }
        public IFormFile Image { get; set; }

        public UploadImageRequest()
        {

        }
        public UploadImageRequest(string body, IFormFile image)
        {
            Body = body;
            Image = image;
        }
    }
    
}
