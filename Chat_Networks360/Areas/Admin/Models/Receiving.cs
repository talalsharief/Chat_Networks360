using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat_Networks360.Areas.HelpPage.Models
{
    public class Receiving
    {
        public class Webhook
        {   

            public Data data { get; set; }
            //public Meta meta { get; set; }
        }

        public class Data
        {
            public string event_type { get; set; }
            public string id { get; set; }
            public string occurred_at { get; set; }
            public payload payload { get; set; }
            public string record_type { get; set; }
        }

        public class payload
        {
            
            public from from { get; set; }
            public string received_at { get; set; }
            public string record_type { get; set; }
            public string text { get; set; }
        }

        public class from
        {
            public string carrier { get; set; }
            public string line_type { get; set; }
            public string phone_number { get; set; }

        }

        public class to
        {
            public string carrier { get; set; }
            public string line_type { get; set; }
            public string phone_number { get; set; }
            public string status { get; set; }
        }

        public class Meta
        {
            public string attempt { get; set; }
            public string delivered_to { get; set; }

        }
    }
}