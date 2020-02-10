﻿using System;
using System.Collections.Generic;

namespace ProjectArcher_Backend.Models
{
    public partial class Company
    {
        public Company()
        {
            Contact = new HashSet<Contact>();
            KeywordCompany = new HashSet<KeywordCompany>();
            MailingCompany = new HashSet<MailingCompany>();
            TimelineCompany = new HashSet<TimelineCompany>();
        }

        public long Id { get; set; }
        public bool IsActive { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string PhoneNumberMobile { get; set; }
        public string PhoneNumberLandline { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Note { get; set; }
        public long? InternalContact { get; set; }
        public long? ExternalContact { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<KeywordCompany> KeywordCompany { get; set; }
        public virtual ICollection<MailingCompany> MailingCompany { get; set; }
        public virtual ICollection<TimelineCompany> TimelineCompany { get; set; }
    }
}
