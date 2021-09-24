using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Result
    {
        public bool Correct { get; set; }
        public Object Object { get; set; }
        public List<Object> Objects { get; set; }
        public string MessageError { get; set; }
        public Exception ex { get; set; }
    }
}
