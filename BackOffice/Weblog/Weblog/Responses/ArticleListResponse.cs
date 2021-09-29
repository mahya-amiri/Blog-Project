using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weblog.ViewModels;

namespace Weblog.Responses
{
    public class ArticleListResponse
    {
        public List<ArticleVM> Data { get; set; }
        public int TotalArticles { get; set; }

        public ArticleListResponse()
        {

        }
        public ArticleListResponse(List<ArticleVM> data, int totalArticles)
        {
            Data = data;
            TotalArticles = totalArticles;
        }
    }
}
