using System.Collections.Generic;
using System.Linq;
using Contrived.Data.Domain;
using Contrived.Data.Services;
using Contrived.Web.Controllers;
using Contrived.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Contrived.Web.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly HomeController _controller;
        
        public HomeControllerTests()
        {
            var mockBlogService = new Mock<BlogService>(null, null);
            mockBlogService.Setup(bs => bs.GetPosts())
                .Returns(new List<Post> {new Post {Id = 1, Title = "Test", AuthorId = 1}});

            mockBlogService.Setup(bs => bs.GetAuthorCounts())
                .Returns(new Dictionary<string, int>());

            mockBlogService.Setup(bs => bs.GetAuthorName(It.IsAny<int>()))
                .Returns("AuthorName");

            mockBlogService.Setup(bs => bs.GetRandomAuthorName())
                .Returns("RandomAuth");

            _controller = new HomeController(mockBlogService.Object);
        }

        [Fact]
        public void CanViewIndexPage()
        {
            var result = (ViewResult)_controller.Index();

            var model = (PostListModel)result.Model;

            Assert.NotNull(model);
            
            Assert.Equal("1", model.Posts.First().Author);
        }

        [Fact]
        public void CanViewRedirectPage()
        {
            var result = (RedirectToActionResult) _controller.Redirect();

            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void CanViewAboutPage()
        {
            var result = (ViewResult) _controller.About();
        }

        [Fact]
        public void CanGetRandomAuthor()
        {
            var result = _controller.RandomAuthor();

            Assert.Equal("RandomAuth", result);
        }

        [Fact]
        public void CanViewContactPage()
        {
            var result = (ViewResult) _controller.Contact();
        }

    }
}