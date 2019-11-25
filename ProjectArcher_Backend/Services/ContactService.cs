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

        public void ContactToCsv(Contact c, string filename)
        {
            ContactToCsv(new Contact[] { c },filename);
        }

        public void ContactToCsv(Contact[] contacts, string filename)
        {

            string firstLine = "Vorname;Nachname;Titel Vorgestellt;Titel nachgestellt;Geschlecht;Position in der Firma;Unternehmen;Aktiv/Inaktiv;Telefon Mobil;TelefonFestnetz;email;Kontaktnotizen;Quelle;interner Kontakt";
            List<string> sContacts = new List<string>();
            sContacts.Add(firstLine);
            foreach (Contact contact in contacts)
            {
                sContacts.Add(ToCsvString(contact));
            }
            File.WriteAllLines(filename, sContacts);
        }

        private string ToCsvString(Contact contact)
        {
            return $"{contact.FirstName};{contact.LastName};{contact.TitlePrefix};{contact.TitlePostfix};{contact.Gender};{contact.Position};{contact.Company};{contact.IsActive};{contact.PhoneNumberMobile};{contact.PhoneNumberLandline};{contact.Email};{contact.Note};{contact.Source};{contact.InternalContact}";
        }
    }
}
