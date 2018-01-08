using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace DataAccess
{
    public class Article
    {
        public int articleId { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public string attachmentUrl { get; set; }
        public DateTime date { get; set; }
        public List<ArticleComment> comments { get; set; }
    }
}
