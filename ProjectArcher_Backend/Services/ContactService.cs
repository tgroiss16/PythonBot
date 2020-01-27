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

        #region export Contact
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
                sContacts.Add(ToContactCsvString(contact));
            }
            File.WriteAllLines(filename, sContacts);
        }
        private string ToContactCsvString(Contact contact)
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
                builder.Append("FN:").Append(contact.TitlePrefix).Append(" " + contact.FirstName).Append(" ").Append(contact.LastName).AppendLine(" " + contact.TitlePostfix);
                builder.Append("N:").Append(contact.TitlePrefix).Append(" " + contact.FirstName).Append(" ").Append(contact.LastName).AppendLine(" " + contact.TitlePostfix);
                builder.Append("ADR;TYPE=WORK,PREF:;;").Append(contact.Company.Street).Append(";").Append(contact.Company.City).Append(";;").Append(contact.Company.PostalCode).Append(";").AppendLine(contact.Company.Country);
                builder.Append("ORG:").AppendLine(contact.Company.Name);
                builder.Append("TITLE:").AppendLine(contact.Position);
                builder.Append("TEL;WORK;VOICE:").AppendLine(contact.PhoneNumberLandline);
                builder.Append("TEL;CELL;VOICE:").AppendLine(contact.PhoneNumberMobile);
                builder.Append("URL:").AppendLine(contact.Company.Website);
                builder.Append("GENDER:").AppendLine(contact.Gender);
                builder.Append("EMAIL;TYPE=INTERNET:").AppendLine(contact.Email);
                builder.Append("NOTE:").AppendLine(contact.Note);
                builder.Append("SOURCE:").AppendLine(contact.Source);
                builder.AppendLine("END:VCARD");
                string filenamecontact = $@"{contact.Company.Name}_{contact.LastName}_{contact.FirstName}.vcf";
                string path = filename + @"\" + filenamecontact;
                File.WriteAllText(path, builder.ToString());
            }
        }
        #endregion export

        #region import Contact
        public List<Contact> ReadContactCSV(string filename)
        {
            List<Contact> list = new List<Contact>();
            string[] arr = File.ReadAllLines(filename).Skip(1).ToArray();
            foreach (var item in arr)
            {
                list.Add(ParseStringToContact(item));
            }
            return list;
        }

        public Contact ReadContactVCF(string filename)
        {
            string[] arr = File.ReadAllLines(filename).ToArray();
            Contact c = new Contact();
            c.Company = new Company();
            foreach (string line in arr)
            {
                if (line.Contains("BEGIN:"))
                {
                    //skip
                }
                else if (line.Contains("NOTE:"))
                {
                    c.Note = line.Split(":")[1];
                }
                else if (line.Contains("SOURCE:"))
                {
                    c.Source = line.Split(":")[1];
                }
                else if (line.Contains("GENDER:"))
                {
                    c.Gender = line.Split(":")[1];
                }
                else if (line.Contains("VERSION:"))
                {
                    //skip
                }
                else if (line.Contains("N:"))
                {
                    if (line.Contains("FN:"))
                    {
                        //nothing
                    }
                    else
                    {
                        //line.Replace(' ', ';');
                        string[] s = line.Split(':')[1].Split(' ');
                        c.TitlePrefix = s[0];
                        c.TitlePostfix = s[2];
                        c.FirstName = s[1];
                        c.LastName = s[3];
                    }
                }
                else if (line.Contains("ADR;"))
                {
                    string[] sist = line.Split(':')[1].Split(';');
                    c.Company.Street = sist[2];
                    c.Company.City = sist[3];
                    c.Company.PostalCode = sist[5];
                    c.Company.Country = sist[6];
                }
                else if (line.Contains("ORG:"))
                {
                    string s = line.Split(':')[1];
                    Company c2 = new Company();
                    c2.Name = s;
                    c.Company = c2;
                }
                else if (line.Contains("TITLE:"))
                {
                    c.Position = line.Split(':')[1];
                }
                else if (line.Contains("TEL;WORK;VOICE:"))
                {
                    c.PhoneNumberLandline = line.Split(':')[1];
                }
                else if (line.Contains("TEL;CELL;VOICE:"))
                {
                    c.PhoneNumberMobile = line.Split(':')[1];
                }
                else if (line.Contains("URL:"))
                {
                    //funkt nu ned
                }
                else if (line.Contains("EMAIL;"))
                {
                    c.Email = line.Split(':')[1];
                }
                else if (line.Contains("END:"))
                {
                    break;
                }
                else
                {
                    //do nothing
                }
            }
            return c;
        }

        private Contact ParseStringToContact(string item)
        {
            string[] arr = item.Split(';');
            Contact c = new Contact();
            c.Id = Int32.Parse(arr[0]);
            c.CompanyId = Int32.Parse(arr[1]);
            c.FirstName = arr[2];
            c.LastName = arr[3];
            c.TitlePrefix = arr[4];
            c.TitlePostfix = arr[5];
            c.Gender = arr[6];
            c.Position = arr[7];
            c.IsActive = bool.Parse(arr[8]);
            c.PhoneNumberMobile = arr[9];
            c.PhoneNumberLandline = arr[10];
            c.Email = arr[11];
            c.Note = arr[12];
            c.Source = arr[13];
            c.InternalContact = long.Parse(arr[14]);
            return c;
        }

        #endregion import

    }
}

