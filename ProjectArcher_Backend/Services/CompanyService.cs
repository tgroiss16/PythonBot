using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Services {
    public class CompanyService : ICompanyService {
        private readonly postgresContext _context;
        public CompanyService(postgresContext context) {
            _context = context;
        }

        public Company AddCompany(Company company)
        {
            var companyToReturn = _context.Company.Add(company).Entity;
            _context.SaveChanges();
            return companyToReturn;
        }

        public Company DeleteCompany(int id)
        {
            var companyToReturn = _context.Company.Remove(GetCompany(id)).Entity;
            _context.SaveChanges();
            return companyToReturn;
        }

        public List<Company> GetCompanys()
        {
            var companies = _context.Company.OrderBy(company => company.Name).ToList();
            _context.SaveChanges();
            return companies;
        }

        public Company GetCompany(int id)
        {
            var companyToReturn = _context.Company.Where(company => company.Id == id).Single();
            _context.SaveChanges();
            return companyToReturn;
        }

        public Company UpdateCompany(Company company)
        {
            var companyToReturn = _context.Company.Update(company).Entity;
            _context.SaveChanges();
            return companyToReturn;
        }

        #region export Company
        public void CompanyToCsv(Company c, string filename)
        {
            CompanyToCsv(new Company[] { c }, filename);
        }
        public void CompanyToCsv(Company[] c, string filename)
        {
            string firstLine = "Id;IsActive;City;PostalCode;Street;Country;PhoneNumberMobile;PhoneNumberLandline;Email;Website;Note;Name";
            var sCompanys = new List<string>();
            sCompanys.Add(firstLine);
            foreach (Company comp in c)
            {
                sCompanys.Add(ToCompanyCsvString(comp));
            }
            File.WriteAllLines(filename, sCompanys);
        }

        private string ToCompanyCsvString(Company company)
        {
            return $"{company.Id};{company.IsActive};{company.City};{company.PostalCode};{company.Street};{company.Country};{company.PhoneNumberMobile};{company.PhoneNumberLandline};{company.Email};{company.Website};{company.Note};{company.Email};{company.Note}";
        }
        #endregion

        #region import Company
        public List<Company> ReadCompanyCSV(string filename)
        {
            List<Company> list = new List<Company>();
            string[] arr = File.ReadAllLines(filename).Skip(1).ToArray();
            foreach (var item in arr)
            {
                list.Add(ParseStringToCompany(item));
            }
            return list;
        }
        private Company ParseStringToCompany(string item)
        {
            string[] arr = item.Split(';');
            Company c = new Company();
            string s = arr[0];
            c.Id = int.Parse(arr[0]);
            c.IsActive = bool.Parse(arr[1]);
            c.City = arr[2];
            c.PostalCode = arr[3];
            c.Street = arr[4];
            c.Country = arr[5];
            c.PhoneNumberMobile = arr[6];
            c.PhoneNumberLandline = arr[7];
            c.Email = arr[8];
            c.Website = arr[9];
            c.Note = arr[10];
            c.Name = arr[11];
            return c;
        }

        public List<Company> FilterCompanys(long? id, bool? isActive, string city, string postalCode, string street, string phoneNumberMobile, string phoneNumberLandline, string email, string website, string note, long? internalContact, long? externalContact, string name)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
