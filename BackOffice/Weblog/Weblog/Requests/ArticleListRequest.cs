namespace Weblog.Requests
{
    public class ArticleListRequest
    {
        public string Query { get; set; }
        public string Sort { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public string Token { get; set; }
        public int? CategoryId { get; set; }

        public ArticleListRequest()
        {
         
        }
        public ArticleListRequest(string query, string sort, int page, int perPage
            , string token, int? categoryId)
        {
            Query = query;
            Sort = sort;
            Page = page;
            PerPage = perPage;
            Token = token;
            CategoryId = categoryId;
        }
    }
}
