using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Inventory
    {
        public int id { get; set; }
        public int amount { get; set; }
        public Product product { get; set; }
        public Sucursal sucursal { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
    }
}
