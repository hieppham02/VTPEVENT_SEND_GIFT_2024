using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTP_Tet
{
    public class ProxyResponse
    {
        public bool success { get; set; }
        public string proxy { get; set; }
        public int location { get; set; }
        public string next_change { get; set; }
        public int timeout { get; set; }
        public string accept_ip { get; set; }
    }
}
