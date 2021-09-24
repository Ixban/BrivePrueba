using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Sucursal
    {
        public int id { get; set; }
        public string sucursalName { get; set; }
        public int telefono { get; set; }
        public string direction { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
    }
}
