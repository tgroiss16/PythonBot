using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectArcher_Backend.Models;
using ProjectArcher_Backend.Services;

namespace ProjectArcher_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<List<Company>> GetAllCompanys()
        {
            return Ok(_companyService.GetCompanys());
        }

        [HttpGet("all/{filter}")]
        public ActionResult<List<Company>> FilterAllProperties(string term) {
            return Ok(_companyService.FilterAllProperties(term));
        }

        [HttpGet("props/{filter}")]
        public ActionResult<List<Company>> FilterAllCompanys(long? id, bool? isActive, string city, string postalCode, string street, string phoneNumberMobile, string phoneNumberLandline, string email, string website, string note, long? internalContact, long? externalContact, string name) {
            return Ok(_companyService.FilterCompanys(id, isActive, city, postalCode, street, phoneNumberMobile, phoneNumberLandline, email, website, note, internalContact, externalContact, name));
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetCompanyPerId(int id)
        {
            return Ok(_companyService.GetCompany(id));
        }

        [HttpDelete("{id}")]
        public ActionResult<Company> DeleteCompany(int id)
        {
            return Ok(_companyService.DeleteCompany(id));
        }

        [HttpPut]
        public ActionResult<Company> UpdateCompany([FromBody] Company company)
        {
            return Ok(_companyService.UpdateCompany(company));
        }

        [HttpPost]
        public ActionResult<Company> AddCompany([FromBody] Company company)
        {
            return Ok(_companyService.AddCompany(company));
        }
    }
}