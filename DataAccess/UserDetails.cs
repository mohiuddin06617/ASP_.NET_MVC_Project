using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDetails
    {
        [Key]
        public string name { get; set; }
        public string occupation { get; set; }
        public string education { get; set; }
        public string skills { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string about { get; set; }
        public string imageUrl { get; set; }
    }
}
