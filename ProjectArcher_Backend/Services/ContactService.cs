using System;
using System.Collections.Generic;
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
            return _context.Contact.OrderBy(contact => contact.FirstName).ToList();
        }

        public Contact AddContact(Contact contact)
        {
            return _context.Contact.Add(contact).Entity;
        }

        public Contact UpdateContact(Contact contact)
        {
            return _context.Contact.Update(contact).Entity;
        }

        public Contact DeleteContact(int id)
        {
            return _context.Contact.Remove(GetContact(id)).Entity;
        }

        public Contact GetContact(int id)
        {
            return _context.Contact.Where(contact => contact.Id == id).Single();
        }
    }
}
