﻿using ProjectArcher_Backend.DTOs;
using ProjectArcher_Backend.Helpers;
using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public interface ICompanyService
    {
        List<Company> GetCompanys();
        Company AddCompany(Company company);
        Company UpdateCompany(Company company);
        Company DeleteCompany(int id);
        Company GetCompany(int id);
        List<Company> FilterAll(string term);
        List<Company> FilterByProperty(List<ExpressionFilter> filters);
        List<Keyword> GetKeywordsForCompany(int companyId);
        KeywordCompany AddKeywordToCompany(KeywordCompany keyword);
        KeywordCompany DeleteKeywordFromCompany(KeywordCompany keyword);
        List<Timeline> GetTimelineObjectsForCompany(int companyId);
        TimelineCompany AddTimelineObjectToCompany(TimelineCompany timeline);
        TimelineCompany DeleteTimelineFromCompany(TimelineCompany timeline);
    }
}
