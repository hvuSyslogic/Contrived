using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Contrived.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Contrived.Web.Models;

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

            var model = posts.Select(p => new PostModel { Id = p.Id, Title = p.Title, Body = p.Body}).ToList();
            
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
