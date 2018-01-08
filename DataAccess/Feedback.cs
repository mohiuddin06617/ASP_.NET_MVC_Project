using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Feedback
    {
        public int id { get; set; }
        public string visitorName { get; set; }
        public string visitorEmail { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
    }
}
