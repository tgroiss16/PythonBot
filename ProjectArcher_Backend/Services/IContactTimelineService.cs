using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public interface IContactTimelineService
    {
        TimelineContact AddTimelineObject(TimelineContact timelineObject);
        TimelineContact GetTimelineObject(int id);
        List<TimelineContact> GetTimelineObjects(int contactId);
        TimelineContact UpdateTimelineObject(TimelineContact timelineObject);
        TimelineContact DeleteTimelineObject(int id);
    }
}
