using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class ArticleController : Controller
    {
        public string Index()
        {
            string msg = "This is Article PAGE!";
            return msg;
        }
    }
}
