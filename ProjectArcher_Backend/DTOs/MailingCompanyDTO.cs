using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.DTOs {
    public class MailingCompanyDTO {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long MailingListId { get; set; }

        public static MailingCompanyDTO Of(MailingCompany mailingCompany)
        {
            return new MailingCompanyDTO
            {
                Id = mailingCompany.Id,
                CompanyId = mailingCompany.Id,
                MailingListId = mailingCompany.MailingListId
            };
        }
    }
}
