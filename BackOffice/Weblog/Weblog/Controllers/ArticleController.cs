using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Weblog.Domain;
using Weblog.Domain.Models;
using Weblog.Requests;
using Weblog.Responses;
using Weblog.Services;
using Weblog.ViewModels;

namespace Weblog.Controllers
{
    [Route("articles")]
    public class ArticleController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly FileHandlerService _fs;
        private readonly IHostingEnvironment _env;
        public ArticleController(IHostingEnvironment env)
        {
            this._db = new DatabaseContext();
            this._fs = new FileHandlerService(env);
            _env = env;
        }

        // Get all articles
        public async Task<ActionResult> Index(ArticleListRequest request)
        {
            try
            {
                var articles = _db.Articles.AsNoTracking();
                if (request.Query != null)
                {
                    articles = articles.Where(x => x.Title.Contains(request.Query) ||
                    x.ShortDescription.Contains(request.Query) ||
                    x.Body.Contains(request.Query));
                }

                articles = request.Sort switch
                {
                    "oldest" => articles.OrderBy(x => x.Id),
                    "latest" => articles.OrderByDescending(x => x.Id),
                    _ => articles.OrderByDescending(x => x.Id)
                };

                var articleCount = articles.Count();
                var result = articles.Skip((request.Page - 1) * request.PerPage).Take(request.PerPage)
                    .Select(x => new ArticleVM(x.Id, x.Title, x.Body, x.ShortDescription, x.Image,
                    x.Status, x.CategoryId, x.UserId, x.CreatedAt, x.UpdatedAt))
                    .ToList();
                return Ok(new ArticleListResponse(result, articleCount));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Store([FromForm] CreateArticleRequest request)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Token == request.Token);
                //var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId);
                var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == 1);

                if (user == null)
                {
                    return Forbid("شما دسترسی لازم برای اضافه کردن مقاله را ندارید");
                }

                if (!user.IsAdmin)
                {
                    return Forbid("شما دسترسی لازم برای اضافه کردن مقاله را ندارید");
                }

                if (category == null)
                {
                    return BadRequest("لطفا دسته بندی مقاله را انتخاب کنید");
                }

                var imageName = Path.GetFileName(request.Image.FileName);
                var imagePath = Path.Combine(_env.WebRootPath, "images\\", imageName);
                string imageroute;
                using (var imageSteam = new FileStream(imagePath, FileMode.Create))
                {
                    await request.Image.CopyToAsync(imageSteam);
                    imageroute = imageSteam.Name;
                }

                //var image = await _fs.Store(request.Image);
                var article = new Article(request.Title, request.Body, request.ShortDescription,
                    imageroute, request.Status, user, category);
                //, user, category);

                _db.Articles.Add(article);
                await _db.SaveChangesAsync();

                return Ok(new ArticleVM(article.Id, article.Title, article.Body, article.ShortDescription,
                    article.Image, article.Status, article.CategoryId, article.UserId, article.CreatedAt, article.UpdatedAt));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //    [HttpPost]
        //    [Route("image")]
        //    public async Task<IActionResult> UploadImage([FromForm] UploadImageRequest request)
        //    {
        //        try
        //        {
        //            var result = await _fs.Store(request.Image);
        //            return Ok(result);
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(e);
        //        }
        //    }
    }
}
