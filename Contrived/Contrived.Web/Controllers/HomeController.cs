using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contrived.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Contrived.Web.Models;
using StackExchange.Profiling;

namespace Contrived.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogService _blogService;

        public HomeController(BlogService blogService)
        {
            _blogService = blogService;
        }


        public IActionResult Index()
        {
            var posts = _blogService.GetPosts();

            var model = new PostListModel
            {
                Posts = posts
                    .Select(p => new PostModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        //Author = p.AuthorId.ToString(),
                        Author = _blogService.GetAuthorName(p.AuthorId),
                        PostDate = p.PostDate,
                        Body = p.Body
                    })
                    .ToList()
            };

            model.AuthorCounts = _blogService.GetAuthorCounts();

            return View(model);
        }

        public IActionResult Redirect()
        {
            using (MiniProfiler.Current.Step("Determine home page"))
            {
                Thread.Sleep(1000);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public string RandomAuthor()
        {
            return _blogService.GetRandomAuthorName();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
