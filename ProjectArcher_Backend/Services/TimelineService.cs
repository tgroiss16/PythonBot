using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectArcher_Backend.Models;

namespace ProjectArcher_Backend.Services
{
    public class TimelineService : ITimelineService
    {
        private readonly postgresContext _context;
        public TimelineService(postgresContext context)
        {
            _context = context;
        }

        public Timeline AddTimelineObject(Timeline timelineObject)
        {
            var timelineToReturn = _context.Timeline.Add(timelineObject).Entity;
            _context.SaveChanges();
            return timelineToReturn;
        }

        public Timeline DeleteTimelineObject(int id)
        {
            var timelineToReturn = _context.Timeline.Remove(GetTimelineObject(id)).Entity;
            _context.SaveChanges();
            return timelineToReturn;
        }

        public Timeline GetTimelineObject(int id)
        {
            return _context.Timeline.First(timeline => timeline.Id == id);
        }

        public Timeline UpdateTimelineObject(Timeline timelineObject)
        {
            var timelineToReturn = _context.Timeline.Update(timelineObject).Entity;
            _context.SaveChanges();
            return timelineToReturn;
        }
    }
}
