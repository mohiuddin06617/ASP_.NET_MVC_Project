using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWEntity
{
    public class Image:Entity
    {
        [Required]
        public string ImageUrl { get; set; }

        public int articleId { get; set; }
        [ForeignKey("articleId")]
        public Article parentArticle { get; set; }



    }
}
