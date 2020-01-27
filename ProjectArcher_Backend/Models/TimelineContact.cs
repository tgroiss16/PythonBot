using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class TimelineContact
    {
        public long TimelineId { get; set; }
        public long ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Timeline Timeline { get; set; }
    }
}
