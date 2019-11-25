using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class Keyword
    {
        public Keyword()
        {
            KeywordCompany = new HashSet<KeywordCompany>();
            KeywordContact = new HashSet<KeywordContact>();
        }

        public long Id { get; set; }
        public string Keyword1 { get; set; }

        public virtual ICollection<KeywordCompany> KeywordCompany { get; set; }
        public virtual ICollection<KeywordContact> KeywordContact { get; set; }
    }
}
