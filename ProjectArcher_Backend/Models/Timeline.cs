using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class Timeline
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual TimelineCompany TimelineCompany { get; set; }
        public virtual TimelineContact TimelineContact { get; set; }
    }
}
