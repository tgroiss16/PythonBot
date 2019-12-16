﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ProjectArcher_Backend.Helpers;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Services {
    public class CompanyService : ICompanyService {
        private readonly postgresContext _context;
        public CompanyService(postgresContext context) {
            _context = context;
        }

        public Company AddCompany(Company company) {
            var companyToReturn = _context.Company.Add(company).Entity;
            _context.SaveChanges();
            return companyToReturn;
        }

        public Company DeleteCompany(int id) {
            var companyToReturn = _context.Company.Remove(GetCompany(id)).Entity;
            _context.SaveChanges();
            return companyToReturn;
        }

        public List<Company> GetCompanys() {
            var companies = _context.Company.OrderBy(company => company.Name).ToList();
            _context.SaveChanges();
            return companies;
        }

        public Company GetCompany(int id) {
            var companyToReturn = _context.Company.Where(company => company.Id == id).Single();
            _context.SaveChanges();
            return companyToReturn;
        }

        public Company UpdateCompany(Company company) {
            var companyToReturn = _context.Company.Update(company).Entity;
            _context.SaveChanges();
            return companyToReturn;
        }

        public List<Company> FilterAll(string term) {
            return _context.Company.Where(c => containsTerm(c, term)).ToList();
        }

        private bool containsTerm(Company c, string term) {
            var allProps = c.GetType()
                .GetProperties()
                .ToList();
            return allProps.Any(p => p.GetValue(c, null)
                        .ToString()
                        .Contains(term));
        }

        public List<Company> FilterByProperty(List<ExpressionFilter> filters) {
            var expressionTree = ExpressionBuilderHelper.ConstructAndExpressionTree<Company>(filters);
            var anonymousFunc = expressionTree.Compile();
            return _context.Company.Where(anonymousFunc).ToList();
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
