using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWEntity
{
    public class Article:Entity
    {
        [Required]
        public string subject { get; set; }
        [Required]
        public string content { get; set; }
        public DateTime date { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public List<Image> images { get; set; }

        //public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public Article parentArticle { get; set; }
    }
}
