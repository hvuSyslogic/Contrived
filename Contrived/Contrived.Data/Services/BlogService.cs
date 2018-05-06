using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contrived.Data.Domain;
using Contrived.Data.Persistence;
using Microsoft.EntityFrameworkCore;
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
            //using (MiniProfiler.Current.Step("Getting top posts"))
            //{
                var count = 7;// _mathService.RandomNumbo();

                var posts = _contrivedContext.Posts
                    //.OrderByDescending(p => p.PostDate)
                    //.Take(count)
                    .ToList();

                return posts;
            //}
        }

        public string GetAuthorName(int authorId)
        {
            return _contrivedContext.Authors
                .FirstOrDefault(a => a.Id == authorId)?.Name ?? "";
        }

        public IDictionary<string, int> GetAuthorCounts()
        {
            return _contrivedContext.Posts
                .Include(p => p.Author)
                .GroupBy(p => p.AuthorId)
                .ToDictionary(gp => gp.First().Author.Name, gp => gp.Count());
        }

        public string GetRandomAuthorName()
        {
            return _contrivedContext.Authors
                .OrderBy(a => Guid.NewGuid())
                .FirstOrDefault()?.Name;
        }
    }
}
