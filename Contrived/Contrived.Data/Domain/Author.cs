using System.Collections.Generic;

namespace Contrived.Data.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}