using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public class ContactTimelineService : IContactTimelineService
    {
        private readonly postgresContext _context;
        public ContactTimelineService(postgresContext context)
        {
            _context = context;
        }

        public TimelineContact AddTimelineObject(TimelineContact timelineObject)
        {
            var timelineContact = _context.TimelineContact.Add(timelineObject).Entity;
            _context.SaveChanges();
            return timelineContact;
        }

        public TimelineContact GetTimelineObject(int id)
        {
            var timelineContact = _context.TimelineContact.Where(timeline => timeline.Id == id).Single();
            _context.SaveChanges();
            return timelineContact;
        }

        public List<TimelineContact> GetTimelineObjects(int contactId)
        {
            var timelineContact = _context.TimelineContact.Where(timeline => timeline.ContactId == contactId)
                .OrderBy(timeline => timeline.Id)
                .ToList();
            _context.SaveChanges();
            return timelineContact;
        }

        public TimelineContact UpdateTimelineObject(TimelineContact timelineObject)
        {
            var timelineContact = _context.TimelineContact.Update(timelineObject).Entity;
            _context.SaveChanges();
            return timelineContact;
        }

        public TimelineContact DeleteTimelineObject(int id)
        {
            var timelineContact = _context.TimelineContact.Remove(GetTimelineObject(id)).Entity;
            _context.SaveChanges();
            return timelineContact;
        }
    }
}
