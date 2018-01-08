using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArticleComment
    {
        public int id { get; set; }
        public string commenterName { get; set; }
        public string commenterEmail { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }
        public int articleId { get; set; }
        

        [ForeignKey("articleId")]
        public Article parentArticle { get; set; }
    }
}
