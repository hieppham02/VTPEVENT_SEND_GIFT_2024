using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTP_Tet
{
    public class RewardResponse
    {
        public Status__ status { get; set; }
        public Data__ data { get; set; }
    }

    public class Data__
    {
        public List<ListGiftItem> listGiftItem { get; set; }
        public bool checkCompleted { get; set; }
    }

    public class ListGiftItem
    {
        public int id { get; set; }
        public string programName { get; set; }
        public string rewardCode { get; set; }
        public string rewardName { get; set; }
        public int quantity { get; set; }
        public int amount { get; set; }
        public DateTime giftingTime { get; set; }
        public string imageUrl { get; set; }
        public string description { get; set; }
    }

    public class Status__
    {
        public string code { get; set; }
        public string message { get; set; }
        public string displayMessage { get; set; }
        public object requestId { get; set; }
    }
}
