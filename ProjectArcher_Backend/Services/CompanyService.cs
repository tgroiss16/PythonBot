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

        public List<Keyword> GetKeywordsForCompany(int companyId)
        {
            var keywordCompanies = _context.KeywordCompany.Where(keyword => keyword.CompanyId == companyId)
                .Select(keywordCompany => keywordCompany.KeywordId)
                .ToList();
            return _context.Keyword.Where(keyword => keywordCompanies.Contains(keyword.Id)).ToList();
        }

        public KeywordCompany AddKeywordToCompany(KeywordCompany keyword)
        {
            var keywordCompany = _context.KeywordCompany.Add(keyword).Entity;
            _context.SaveChanges();
            return keywordCompany;

        }

        public KeywordCompany DeleteKeywordFromCompany(KeywordCompany keyword)
        {
            var keywordCompany = _context.KeywordCompany.Remove(keyword).Entity;
            _context.SaveChanges();
            return keywordCompany;
        }
    }
}
