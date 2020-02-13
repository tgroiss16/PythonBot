using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.DTOs {
    public class MailingContactDTO {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public long MailingListId { get; set; }

        public static MailingContactDTO Of(MailingContact mailingContact)
        {
            return new MailingContactDTO()
            {
                Id = mailingContact.Id,
                ContactId = mailingContact.ContactId,
                MailingListId = mailingContact.MailingListId
            };
        }
    }
}
