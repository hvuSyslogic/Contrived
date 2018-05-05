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
            using (MiniProfiler.Current.Step("Getting top posts"))
            {
                var count = _mathService.RandomNumbo();

                var posts = _contrivedContext.Posts
                    .OrderByDescending(p => p.PostDate)
                    .Take(count)
                    .ToList();

                return posts;
            }
        }
        
    }
}
