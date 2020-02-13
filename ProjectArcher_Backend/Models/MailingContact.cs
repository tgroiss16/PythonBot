using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class MailingContact
    {
        public long ContactId { get; set; }
        public long MailingListId { get; set; }
        public long Id { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual MailingList MailingList { get; set; }
    }
}
