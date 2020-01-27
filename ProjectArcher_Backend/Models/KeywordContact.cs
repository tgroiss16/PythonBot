using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class KeywordContact
    {
        public long KeywordId { get; set; }
        public long ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Keyword Keyword { get; set; }
    }
}
