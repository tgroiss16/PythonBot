using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Models {
    public class MailingList {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime SendDate { get; set; }

        public virtual ICollection<MailingCompany> Companys { get; set; }

        public virtual ICollection<MailingContact> Contacts { get; set; }
    }
}
