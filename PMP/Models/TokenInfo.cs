using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMP
{
    public class TokenInfo
    {
        public int? ClientID { get; set; }
        public int? ContactPersonID { get; set; }
        public DateTime? ContactDate { get; set; }
        public int? ChannelID { get; set; }
        public int? SourceID { get; set; }
        public int? EquityTypeID { get; set; }
        public string Objective { get; set; }
        public string Target { get; set; }

    }
}