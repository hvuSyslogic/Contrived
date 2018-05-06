using System;

namespace Contrived.Data.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public virtual Blog Blog { get; set; }
        public virtual Author Author { get; set; }
    }
}