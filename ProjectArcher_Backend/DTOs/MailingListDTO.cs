using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.DTOs {
    public class MailingListDTO {

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime SendDate { get; set; }

        public static MailingListDTO Of(MailingList mailingList)
        {
            return new MailingListDTO {
                Id = mailingList.Id,
                Name = mailingList.Name,
                SendDate = mailingList.SendDate
            };
        }
    }
}
