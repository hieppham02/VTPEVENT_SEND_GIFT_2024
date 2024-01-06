using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTP_Tet
{
    public class CheckVisitResponse
    {
        public Status status { get; set; }
        public Data data { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        public int visitsInDay { get; set; }
        public int joinProgram { get; set; }
        public string programCode { get; set; }
        public List<Gift> gifts { get; set; }
    }

    public class Gift
    {
        public string giftCode { get; set; }
        public string giftName { get; set; }
        public string highResImg { get; set; }
        public object lowResImg { get; set; }
        public string description { get; set; }
    }
    public class Status
    {
        public string code { get; set; }
        public string message { get; set; }
        public string displayMessage { get; set; }
        public object requestId { get; set; }
    }
}
