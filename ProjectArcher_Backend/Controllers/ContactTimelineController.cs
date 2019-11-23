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
    public class ContactTimelineController : ControllerBase
    {
        private readonly IContactTimelineService _contactTimelineService;
        public ContactTimelineController(IContactTimelineService contactTimelineService)
        {
            _contactTimelineService = contactTimelineService;
        }

        [HttpGet("all/{id}")]
        public ActionResult<List<TimelineContact>> GetAllContactTimelines(int id)
        {
            return Ok(_contactTimelineService.GetTimelineObjects(id));
        }

        [HttpGet("{id}")]
        public ActionResult<TimelineContact> GetContactTimelinePerId(int id)
        {
            return Ok(_contactTimelineService.GetTimelineObject(id));
        }

        [HttpDelete("{id}")]
        public ActionResult<TimelineContact> DeleteContactTimeline(int id)
        {
            return Ok(_contactTimelineService.DeleteTimelineObject(id));
        }

        [HttpPut]
        public ActionResult<TimelineContact> UpdateContactTimeline([FromBody] TimelineContact timeline)
        {
            return Ok(_contactTimelineService.UpdateTimelineObject(timeline));
        }

        [HttpPost]
        public ActionResult<TimelineContact> AddContactTimeline([FromBody] TimelineContact timeline)
        {
            return Ok(_contactTimelineService.AddTimelineObject(timeline));
        }
    }
}
