using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            ContactToCsv(new Contact[] { c }, filename);
        }

        public void ContactToCsv(Contact[] contacts, string filename)
        {

            string firstLine = "Vorname;Nachname;Titel Vorgestellt;Titel nachgestellt;Geschlecht;Position in der Firma;Unternehmen;Aktiv/Inaktiv;Telefon Mobil;TelefonFestnetz;email;Kontaktnotizen;Quelle;interner Kontakt";
            var sContacts = new List<string>();
            sContacts.Add(firstLine);
            foreach (Contact contact in contacts)
            {
                sContacts.Add(ToCsvString(contact));
            }
            File.WriteAllLines(filename, sContacts);
        }

        private string ToCsvString(Contact contact)
        {
            return $"{contact.FirstName};{contact.LastName};{contact.TitlePrefix};{contact.TitlePostfix};{contact.Gender};{contact.Position};{contact.Company.Name};{contact.IsActive};{contact.PhoneNumberMobile};{contact.PhoneNumberLandline};{contact.Email};{contact.Note};{contact.Source};{contact.InternalContact}";
        }

        public void ContactToVcf(Contact c, string filename)
        {
            ContactToVcf(new Contact[] { c }, filename);
        }

        public void ContactToVcf(Contact[] contacts, string filename)
        {
            foreach (var contact in contacts)
            {
                var builder = new StringBuilder();
                builder.AppendLine("BEGIN:VCARD");
                builder.AppendLine("VERSION:2.1");
                builder.Append("N:").Append(contact.LastName)
                  .Append(";").AppendLine(contact.FirstName);
                builder.Append("FN:").Append(contact.FirstName)
                  .Append(" ").AppendLine(contact.LastName);
                builder.Append("ADR;HOME;PREF:;;").Append(contact.Company.Street)
                  .Append(";").Append(contact.Company.City).Append(";")
                  .Append(contact.Company.PostalCode).Append(";").AppendLine(contact.Company.Country);
                builder.Append("ORG:").AppendLine(contact.Company.Name);
                builder.Append("TITLE:").AppendLine(contact.TitlePrefix);
                builder.Append("TITLE2:").AppendLine(contact.TitlePostfix);
                builder.Append("TEL;WORK;VOICE:").AppendLine(contact.PhoneNumberLandline);
                builder.Append("TEL;CELL;VOICE:").AppendLine(contact.PhoneNumberMobile);
                builder.Append("URL:").AppendLine(contact.Company.Website);
                builder.Append("EMAIL;PREF;INTERNET:").AppendLine(contact.Email);

                builder.AppendLine("END:VCARD");
                string filenamecontact = $@"{filename}_{contact.Company.Name}_{contact.LastName}_{contact.FirstName} .vcf";
                File.WriteAllText(filenamecontact, builder.ToString());
            }
        }
    }
}
