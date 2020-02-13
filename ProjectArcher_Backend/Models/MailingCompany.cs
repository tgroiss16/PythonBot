using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class MailingCompany
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long MailingListId { get; set; }

        public virtual Company Company { get; set; }
        public virtual MailingList MailingList { get; set; }
    }
}
