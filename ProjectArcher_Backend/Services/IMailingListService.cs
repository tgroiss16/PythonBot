using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Services {
    public interface IMailingListService
    {
        MailingList AddMailingList(MailingList mailingList);
        MailingList GetMailingList(int id);
        MailingList DeleteMailingList(int id);
        MailingList UpdateMailingList(MailingList mailingList);
        List<MailingList> GetAllMailingLists();
    }
}
