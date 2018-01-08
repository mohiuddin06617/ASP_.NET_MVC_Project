using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWEntity
{
    public class Category:Entity
    {
        [Required]
        public string CategoryName { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
    }
}
