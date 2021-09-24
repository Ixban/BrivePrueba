using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
    }
}
