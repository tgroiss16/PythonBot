using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Services {
    public class MailingListService: IMailingListService {

        private readonly postgresContext _context;
        public MailingListService(postgresContext context) {
            _context = context;
        }

        public MailingList AddMailingList(MailingList mailingList)
        {
            var mail = _context.MailingList.Add(mailingList).Entity;
            _context.SaveChanges();
            return mail;
        }

        public MailingList GetMailingList(int id)
        {
            var mail = _context.MailingList.First(x => x.Id == id);
            _context.SaveChanges();
            return mail;
        }

        public MailingList DeleteMailingList(int id)
        {
            var mail = _context.MailingList.Remove(GetMailingList(id)).Entity;
            _context.SaveChanges();
            return mail;
        }

        public MailingList UpdateMailingList(MailingList mailingList)
        {
            var mail = _context.MailingList.Update(mailingList).Entity;
            _context.SaveChanges();
            return mail;
        }

        public List<MailingList> GetAllMailingLists()
        {
            var all = _context.MailingList.OrderBy(x => x.SendDate).ToList();
            _context.SaveChanges();
            return all;
        }
    }
}
