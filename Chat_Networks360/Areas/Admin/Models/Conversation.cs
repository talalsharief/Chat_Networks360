using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat_Networks360.Areas.HelpPage.Models
{
    public class Conversation
    {

        public int Id { get; set; }
        public string Inbound_Number { get; set; }
        public string OutBound_Number { get; set; }
        public string Created_At { get; set; }
        public string Received_At { get; set; }
        public string Message { get; set; }
    }
}