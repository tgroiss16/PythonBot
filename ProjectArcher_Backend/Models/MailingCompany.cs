using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Models {
    public class MailingCompany {
        public long Id { get; set; }

        public long CompanyId { get; set; }
        public long MailingListId { get; set; }
        public virtual Company Company { get; set; }
        public virtual MailingList MailingList { get; set; }

    }
}
