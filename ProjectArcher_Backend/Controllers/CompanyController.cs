using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectArcher_Backend.DTOs;
using ProjectArcher_Backend.Helpers;
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
        public ActionResult<List<CompanyDTO>> GetAllCompanys()
        {
            return Ok(_companyService.GetCompanys().Select(x => CompanyDTO.Of(x)).ToList());
        }

        [HttpGet("filter/{all}")]
        public ActionResult<List<CompanyDTO>> FilterAll(string term) {
            return Ok(_companyService.FilterAll(term).Select(x => CompanyDTO.Of(x)).ToList());
        }

        [HttpGet("filter")]
        public ActionResult<List<CompanyDTO>> FilterByProperty([FromBody] List<ExpressionFilter> filters) {
            return Ok(_companyService.FilterByProperty(filters).Select(x => CompanyDTO.Of(x)).ToList());
        }


        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> GetCompanyPerId(int id)
        {
            return Ok(CompanyDTO.Of(_companyService.GetCompany(id)));
        }

        [HttpDelete("{id}")]
        public ActionResult<CompanyDTO> DeleteCompany(int id)
        {
            return Ok(CompanyDTO.Of(_companyService.DeleteCompany(id)));
        }

        [HttpPut]
        public ActionResult<CompanyDTO> UpdateCompany([FromBody] Company company)
        {
            return Ok(CompanyDTO.Of(_companyService.UpdateCompany(company)));
        }

        [HttpPost]
        public ActionResult<CompanyDTO> AddCompany([FromBody] Company company)
        {
            return Ok(CompanyDTO.Of(_companyService.AddCompany(company)));
        }

        [HttpPost("keyword")]
        public ActionResult<KeywordCompanyDTO> AddCompanyKeyword([FromBody] KeywordCompany keyword)
        {
            return Ok(KeywordCompanyDTO.Of(_companyService.AddKeywordToCompany(keyword)));
        }

        [HttpDelete("keyword")]
        public ActionResult<KeywordCompanyDTO> DeleteKeywordFromCompany([FromBody] KeywordCompany keyword)
        {
            return Ok(KeywordCompanyDTO.Of(_companyService.DeleteKeywordFromCompany(keyword)));
        }

        [HttpGet("keyword/{id}")]
        public ActionResult<List<KeywordDTO>> GetKeywordsForCompany(int companyId)
        {
            return Ok(_companyService.GetKeywordsForCompany(companyId).Select(x => KeywordDTO.Of(x)).ToList());
        }

        [HttpPost("timeline")]
        public ActionResult<TimelineCompanyDTO> AddTimelineObjectToCompany([FromBody] TimelineCompany keyword)
        {
            return Ok(TimelineCompanyDTO.Of(_companyService.AddTimelineObjectToCompany(keyword)));
        }

        [HttpDelete("timeline")]
        public ActionResult<TimelineCompanyDTO> DeleteTimelineFromCompany([FromBody] TimelineCompany keyword)
        {
            return Ok(TimelineCompanyDTO.Of(_companyService.DeleteTimelineFromCompany(keyword)));
        }

        [HttpGet("timeline/{id}")]
        public ActionResult<List<TimelineDTO>> GetTimelineObjectsForCompany(int companyId)
        {
            return Ok(_companyService.GetTimelineObjectsForCompany(companyId).Select(x => TimelineDTO.Of(x)).ToList());
        }
    }
}