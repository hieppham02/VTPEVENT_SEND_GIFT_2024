using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTP_Tet
{
    public class RecivedItems
    {
        public List<Items> items { get; set; }
    }
    public class Items
    {
        public string name { get; set; }
        public string quantity { get; set; }
    }

}
