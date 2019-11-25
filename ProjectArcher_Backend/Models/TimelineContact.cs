using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class TimelineContact
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
