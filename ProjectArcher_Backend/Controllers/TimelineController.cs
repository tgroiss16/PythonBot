using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectArcher_Backend.DTOs;
using ProjectArcher_Backend.Models;
using ProjectArcher_Backend.Services;

namespace ProjectArcher_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimelineController : ControllerBase
    {
        private readonly ITimelineService _timelineService;
        public TimelineController(ITimelineService timelineService)
        {
            _timelineService = timelineService;
        }

        [HttpGet("{id}")]
        public ActionResult<TimelineDTO> GetTimelinePerId(int id)
        {
            return Ok(TimelineDTO.Of(_timelineService.GetTimelineObject(id)));
        }

        [HttpDelete("{id}")]
        public ActionResult<TimelineDTO> DeleteContactTimeline(int id)
        {
            return Ok(TimelineDTO.Of(_timelineService.DeleteTimelineObject(id)));
        }

        [HttpPut]
        public ActionResult<TimelineDTO> UpdateContactTimeline([FromBody] Timeline timeline)
        {
            return Ok(TimelineDTO.Of(_timelineService.UpdateTimelineObject(timeline)));
        }

        [HttpPost]
        public ActionResult<TimelineDTO> AddContactTimeline([FromBody] Timeline timeline)
        {
            return Ok(TimelineDTO.Of(_timelineService.AddTimelineObject(timeline)));
        }
    }
}
