﻿using System.Collections.Generic;
using MailChimp.Api.Net.Domain.Reports;

namespace MailChimp.Api.Net.Domain.Lists
{
    public class RootAbuseReport
    {
        public List<AbuseReport> abuse_reports { get; set; }
        public string list_id { get; set; }
        public int total_items { get; set; }
        public List<Link> _links { get; set; }
    }
}
