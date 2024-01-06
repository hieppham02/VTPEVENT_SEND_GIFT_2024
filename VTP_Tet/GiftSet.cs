using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTP_Tet
{
    public class GiftSet
    {
        public Status_ status { get; set; }
        public Data_ data { get; set; }
    }
    public class Data_
    {
        public List<GiftSetType> giftSetTypes { get; set; }
    }

    public class GiftSetInfo
    {
        public int id { get; set; }
        public int giftSetTypeId { get; set; }
        public string giftSetCode { get; set; }
        public string giftSetName { get; set; }
        public string highResImg { get; set; }
        public object lowResImg { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
        public int quantity { get; set; }
        public int quantityPerSet { get; set; }
        public int expiredHours { get; set; }
    }

    public class GiftSetType
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string programCode { get; set; }
        public string highResImg { get; set; }
        public object lowResImg { get; set; }
        public object json { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int priority { get; set; }
        public string giftsImg { get; set; }
        public List<GiftSetInfo> giftSetInfo { get; set; }
    }
    public class Status_
    {
        public string code { get; set; }
        public string message { get; set; }
        public string displayMessage { get; set; }
        public object requestId { get; set; }
    }
}
