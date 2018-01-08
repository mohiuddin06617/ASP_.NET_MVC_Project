using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWEntity.ViewModels
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
