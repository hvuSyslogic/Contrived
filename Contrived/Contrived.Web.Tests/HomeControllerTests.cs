using System.Linq;
using Contrived.Data.Persistence;
using Contrived.Data.Services;
using Contrived.Web.Controllers;
using Contrived.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Contrived.Web.Tests
{
    public class HomeControllerTests
    {
        //private readonly BlogService _blogService;
        private readonly ContrivedContext _context;

        public HomeControllerTests()
        {
            var dbOptions = new DbContextOptionsBuilder<ContrivedContext>()
                .UseInMemoryDatabase(nameof(HomeControllerTests))
                .Options;
            _context = new ContrivedContext(dbOptions);
            
            //_blogService = new BlogService(new MathService(), _context);
        }

        [Fact]
        public void CanViewIndexPage()
        {
            var posts = _context.Posts.ToList();

            //var target = new HomeController(_blogService);

            //var result = (ViewResult)target.Index();

            //var model = (PostListModel) result.Model;

            //Assert.NotNull(model);
        }
    }
}