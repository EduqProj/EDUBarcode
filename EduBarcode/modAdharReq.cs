using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBarcode
{
    internal class modAdharReq
    {
        public bool failed { get; set; }
        public string text { get; set; }
        public string Message { get; set; }
    }

    class adharvalid
    {
        public string roll_no { get; set; }
        public string uid { get; set; }
        public string  bio { get; set; }
    }
}
