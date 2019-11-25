using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class TimelineCompany
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual Company Company { get; set; }
    }
}
