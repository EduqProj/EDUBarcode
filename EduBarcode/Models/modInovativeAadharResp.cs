using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBarcode.Models
{
    internal class modInovativeAadharResp
    {
        public string status { get; set; }
        public string statusCode { get; set; }
        public string errCode { get; set; }
        public string message { get; set; }
        public JsonData data { get; set; }
    }
    public class JsonData
    {
        public string ret { get; set; }
        public string info { get; set; }
        public string txn { get; set; }
    }
}
