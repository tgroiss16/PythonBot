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

        List<Company> FilterCompanys(long? id, bool? isActive, string city, string postalCode, string street, string phoneNumberMobile, 
            string phoneNumberLandline, string email, string website, string note, long? internalContact, long? externalContact, string name);
    }
}
