using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat_Networks360.Areas.HelpPage.Models
{
    public class Messaging
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string received_at { get; set; }
        public string InboundNumber { get; set; }
        public string OutBoundNumber { get; set; }
        public string CreatedAt { get; set; }
    }
}