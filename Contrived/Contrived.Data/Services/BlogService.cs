using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contrived.Data.Domain;
using Contrived.Data.Persistence;
using StackExchange.Profiling;

namespace Contrived.Data.Services
{
    public class BlogService
    {
        private readonly MathService _mathService;
        private readonly ContrivedContext _contrivedContext;

        public BlogService(MathService mathService, ContrivedContext contrivedContext)
        {
            _mathService = mathService;
            _contrivedContext = contrivedContext;
        }

        public IList<Post> GetPosts()
        {
            using (MiniProfiler.Current.Step("Getting all posts"))
            {
                var count = _mathService.RandomNumbo();

                var posts = _contrivedContext.Posts.ToList();

                return new List<Post>()
                {
                    new Post { Id = 1, Title = $"New Post {count}", Body = "Post Content" },
                    new Post { Id = 2, Title = $"New Post {posts.Count}", Body = "Post Content" },
                    new Post { Id = 3, Title = "New Post  3", Body = "Post Content" },
                };
            }
        }
        
    }
}
