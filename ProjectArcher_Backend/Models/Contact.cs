using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class Contact
    {
        public Contact()
        {
            TimelineContact = new HashSet<TimelineContact>();
        }

        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitlePrefix { get; set; }
        public string TitlePostfix { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumberMobile { get; set; }
        public string PhoneNumberLandline { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string Source { get; set; }
        public long InternalContact { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<TimelineContact> TimelineContact { get; set; }
    }
}
