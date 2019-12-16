using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Services
{
    public class ContactService : IContactService
    {
        private readonly postgresContext _context;
        public ContactService(postgresContext context)
        {
            _context = context;
        }

        public List<Contact> GetContacts()
        {
            var contactToReturn = _context.Contact.OrderBy(contact => contact.FirstName).ToList();
            _context.SaveChanges();
            return contactToReturn;
        }

        public Contact AddContact(Contact contact)
        {
            var contactToReturn = _context.Contact.Add(contact).Entity;
            _context.SaveChanges();
            return contactToReturn;
        }

        public Contact UpdateContact(Contact contact)
        {
            var contactToReturn = _context.Contact.Update(contact).Entity;
            _context.SaveChanges();
            return contactToReturn;
        }

        public Contact DeleteContact(int id)
        {
            var contactToReturn = _context.Contact.Remove(GetContact(id)).Entity;
            _context.SaveChanges();
            return contactToReturn;
        }

        public Contact GetContact(int id)
        {
            var contactToReturn = _context.Contact.Where(contact => contact.Id == id).Single();
            _context.SaveChanges();
            return contactToReturn;
        }

        public List<Keyword> GetKeywordsForContact(int contactId)
        {
            var keywordContacts = _context.KeywordContact.Where(keyword => keyword.ContactId == contactId)
                .Select(keywordCompany => keywordCompany.KeywordId)
                .ToList();
            return _context.Keyword.Where(keyword => keywordContacts.Contains(keyword.Id)).ToList();
        }

        public KeywordContact AddKeywordToContact(KeywordContact keyword)
        {
            var keywordContact = _context.KeywordContact.Add(keyword).Entity;
            _context.SaveChanges();
            return keywordContact;
        }

        public KeywordContact DeleteKeywordFromContact(KeywordContact keyword)
        {
            var keywordContact = _context.KeywordContact.Remove(keyword).Entity;
            _context.SaveChanges();
            return keywordContact;
        }
    }
}
