using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Models {
    public class MailingContact {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public long MailingListId { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual MailingList MailingList { get; set; }   
    }
}
