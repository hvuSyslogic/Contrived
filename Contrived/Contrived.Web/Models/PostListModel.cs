using System.Collections.Generic;

namespace Contrived.Web.Models
{
    public class PostListModel
    {
        public IList<PostModel> Posts { get; set; }
        public IDictionary<string, int> AuthorCounts { get; set; }
    }
}