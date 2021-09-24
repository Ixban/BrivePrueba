using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Log
    {
        public int id { get; set; }
        public Users users { get; set; }
        public string action { get; set; }
        public string module { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
    }
}
