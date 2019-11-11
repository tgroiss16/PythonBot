using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly postgresContext _context;
        public CompanyService(postgresContext context)
        {
            _context = context;
        }

        public Company AddCompany(Company company)
        {
            return _context.Company.Add(company).Entity;
        }

        public Company DeleteCompany(int id)
        {
            return _context.Company.Remove(GetCompany(id)).Entity;
        }

        public List<Company> GetCompanys()
        {
            return _context.Company.OrderBy(company => company.Name).ToList();
        }

        public Company GetCompany(int id)
        {
            return _context.Company.Where(company => company.Id == id).Single();
        }

        public Company UpdateCompany(Company company)
        {
            return _context.Company.Update(company).Entity;
        }
    }
}
