using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Contrived.Data.Domain
{
    [Table("tblBlog")]
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
