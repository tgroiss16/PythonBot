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
    }
}
