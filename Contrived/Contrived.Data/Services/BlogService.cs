using System;
using System.Collections.Generic;
using System.Text;
using Contrived.Data.Domain;

namespace Contrived.Data.Services
{
    public class BlogService
    {
        public IList<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post { Id = 1, Title = "New Post 1", Body = "Post Content" },
                new Post { Id = 2, Title = "New Post2", Body = "Post Content" },
                new Post { Id = 3, Title = "New Post  3", Body = "Post Content" },
            };
        }
        
    }
}
