using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class TimelineCompany
    {
        public long TimelineId { get; set; }
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Timeline Timeline { get; set; }
    }
}
