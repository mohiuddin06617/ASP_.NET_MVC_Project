using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWEntity
{
    public class ArticleComment:Entity
    {
        [Required]
        public string commenterName { get; set; }
        [Required]
        public string commenterEmail { get; set; }
        [Required]
        public string comment { get; set; }
        public DateTime date { get; set; }

        public int articleId { get; set; }

        //[ForeignKey("articleId")]
        //public Article parentArticle { get; set; }
        
    }
}
