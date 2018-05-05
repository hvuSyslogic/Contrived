using System;
using System.Collections.Generic;
using System.Text;

namespace Contrived.Data.Domain
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
