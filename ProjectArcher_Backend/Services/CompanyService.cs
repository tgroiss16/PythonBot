using System;
using System.Collections.Generic;
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

        public List<Company> FilterCompanys(long? id, bool? isActive, string city, string postalCode, string street,
            string phoneNumberMobile, string phoneNumberLandline, string email, string website, string note, long? internalContact,
            long? externalContact, string name)
        {
            city = city ?? "";
            postalCode = postalCode ?? "";
            street = street ?? "";
            phoneNumberMobile = phoneNumberMobile ?? "";
            phoneNumberLandline = phoneNumberLandline ?? "";
            email = email ?? "";
            website = website ?? "";
            note = note ?? "";
            name = name ?? "";

            var filtered2 = new List<Company>();
            filtered2.Add(new Company { IsActive = true, City = "sven", Email="jdsfkj", PostalCode = "sdjf", Street= "jsdkf", PhoneNumberLandline = "99", PhoneNumberMobile="34", Website = "skdjf", Name="kdsjf", Note="jkdsjf" });
            filtered2.Add(new Company { IsActive = false, City = "sven", Email="jdsfkj", PostalCode = "sdjf", Street= "jsdkf", PhoneNumberLandline = "99", PhoneNumberMobile="34", Website = "skdjf", Name="kdsjf", Note="jkdsjf" });
            filtered2.Add(new Company { City = "sven", Email="jdsfkj", PostalCode = "sdjf", Street= "jsdkf", PhoneNumberLandline = "99", PhoneNumberMobile="34", Website = "skdjf", Name="kdsjf", Note="jkdsjf" });

            var filtered = filtered2.Where(c => c.City.Contains(city)
                && c.PostalCode.Contains(postalCode)
                && c.Street.Contains(street)
                && c.PhoneNumberMobile.Contains(phoneNumberMobile)
                && c.PhoneNumberLandline.Contains(phoneNumberLandline)
                && c.Email.Contains(email)
                && c.Website.Contains(website)
                && c.Note.Contains(note)
                && c.Name.Contains(name));

            if (id != null)
            {
                filtered = filtered.Where(c => c.Id == id);
            }
            if (isActive != null)
            {
                filtered = filtered.Where(c => c.IsActive == isActive);
            }
            if (internalContact != null)
            {
                filtered = filtered.Where(c => c.InternalContact == internalContact);
            }
            if (externalContact != null)
            {
                filtered = filtered.Where(c => c.ExternalContact == externalContact);
            }
            return filtered.ToList();
        }
    }
}
