using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Helpers {
    public class CsvHelper {
        public static StringBuilder ToCsv(List<Company> companies) {
            // id, name, email, website, isActive, city, postalCode, street, country, phoneMobile, phoneLandline, note, internal, external
            var csv = new StringBuilder();
            string header = "Id;Name;Email;Website;IsActive;City;PostalCode;Street;Country;PhoneNumberMobile;PhoneNumberLandline;Note;InternalContact;ExternalContact";
            csv.AppendLine(header);
            foreach (var c in companies) {
                string line = $"{c.Id};{c.Name};{c.Email};{c.Website};{c.IsActive};{c.City};{c.PostalCode};{c.Street};{c.Country};{c.PhoneNumberMobile};{c.PhoneNumberLandline};{c.Note};{c.InternalContact};{c.ExternalContact}";
                csv.AppendLine(line);
            }

            return csv;
        }

        public static StringBuilder ToCsv(List<Contact> contacts) {
            // id, firstName, lastName, gender, position, titlePrefix, titlePostfix, email, source, companyId, isActive, phoneMobile, phoneLandline, note, internal
            var csv = new StringBuilder();
            string header = "Id;FirstName;LastName;Gender;Position;TitlePrefix;TitlePostfix;Email;Source;CompanyId;IsActive;PhoneNumberMobile;PhoneNumberLandline;Note;InternalContact";
            csv.AppendLine(header);
            foreach (var c in contacts) {
                string line = $"{c.Id};{c.FirstName};{c.LastName};{c.Gender};{c.Position};{c.TitlePrefix};{c.TitlePostfix};{c.Email};{c.Source};{c.CompanyId};{c.IsActive};{c.PhoneNumberMobile};{c.PhoneNumberLandline};{c.Note};{c.InternalContact}";
                csv.AppendLine(line);
            }

            return csv;
        }
    }
}
