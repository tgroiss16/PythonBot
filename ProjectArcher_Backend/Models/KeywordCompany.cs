using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class KeywordCompany
    {
        public long Id { get; set; }
        public long KeywordId { get; set; }
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Keyword Keyword { get; set; }
    }
}
