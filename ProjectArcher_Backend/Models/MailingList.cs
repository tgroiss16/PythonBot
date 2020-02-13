using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class MailingList
    {
        public MailingList()
        {
            MailingCompany = new HashSet<MailingCompany>();
            MailingContact = new HashSet<MailingContact>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? SendDate { get; set; }

        public virtual ICollection<MailingCompany> MailingCompany { get; set; }
        public virtual ICollection<MailingContact> MailingContact { get; set; }
    }
}
