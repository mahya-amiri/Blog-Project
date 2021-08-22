using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weblog.Domain;

namespace Weblog.Controllers
{
    [Route("articles")]
    public class ArticleController : ControllerBase
    {
        private readonly DatabaseContext _db;
        public ArticleController()
        {
            this._db = new DatabaseContext();
        }
        //public IActionResult Index()
        //{
        //    try
        //    {
        //        var articles = _db.Articles
        //            .Select()
        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
