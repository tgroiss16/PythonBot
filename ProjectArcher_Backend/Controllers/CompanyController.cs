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

        [HttpPost("keyword")]
        public ActionResult<KeywordCompany> AddCompanyKeyword([FromBody] KeywordCompany keyword)
        {
            return Ok(_companyService.AddKeywordToCompany(keyword));
        }

        [HttpDelete("keyword")]
        public ActionResult<KeywordCompany> DeleteKeywordFromCompany([FromBody] KeywordCompany keyword)
        {
            return Ok(_companyService.DeleteKeywordFromCompany(keyword));
        }

        [HttpGet("keyword/{id}")]
        public ActionResult<List<Keyword>> GetKeywordsForCompany(int companyId)
        {
            return Ok(_companyService.GetKeywordsForCompany(companyId));
        }
    }
}