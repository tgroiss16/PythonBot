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
    public class CompanyTimelineController : ControllerBase
    {
        private readonly ICompanyTimelineService _companyTimelineService;
        public CompanyTimelineController(ICompanyTimelineService companyTimelineService)
        {
            _companyTimelineService = companyTimelineService;
        }

        [HttpGet("all/{id}")]
        public ActionResult<List<TimelineCompany>> GetAllContactTimelines(int id)
        {
            return Ok(_companyTimelineService.GetTimelineObjects(id));
        }

        [HttpGet("{id}")]
        public ActionResult<TimelineCompany> GetContactTimelinePerId(int id)
        {
            return Ok(_companyTimelineService.GetTimelineObject(id));
        }

        [HttpDelete("{id}")]
        public ActionResult<TimelineCompany> DeleteContactTimeline(int id)
        {
            return Ok(_companyTimelineService.DeleteTimelineObject(id));
        }

        [HttpPut]
        public ActionResult<TimelineCompany> UpdateContactTimeline([FromBody] TimelineCompany timeline)
        {
            return Ok(_companyTimelineService.UpdateTimelineObject(timeline));
        }

        [HttpPost]
        public ActionResult<TimelineCompany> AddContactTimeline([FromBody] TimelineCompany timeline)
        {
            return Ok(_companyTimelineService.AddTimelineObject(timeline));
        }
    }
}
