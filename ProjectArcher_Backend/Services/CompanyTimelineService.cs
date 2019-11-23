using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public class CompanyTimelineService : ICompanyTimelineService
    {
        private readonly postgresContext _context;
        public CompanyTimelineService(postgresContext context)
        {
            _context = context;
        }

        public TimelineCompany AddTimelineObject(TimelineCompany timelineObject)
        {
            var timelineCompany = _context.TimelineCompany.Add(timelineObject).Entity;
            _context.SaveChanges();
            return timelineCompany;
        }

        public TimelineCompany GetTimelineObject(int id)
        {
            var timelineCompany = _context.TimelineCompany.Where(companyTimeline => companyTimeline.Id == id).Single();
            _context.SaveChanges();
            return timelineCompany;
        }

        public List<TimelineCompany> GetTimelineObjects(int companyId)
        {
            var timelineCompany = _context.TimelineCompany.Where(companyTimeline => companyTimeline.CompanyId == companyId)
                    .OrderBy(companyTimeline => companyTimeline.Id)
                    .ToList();
            _context.SaveChanges();
            return timelineCompany;
        }

        public TimelineCompany UpdateTimelineObject(TimelineCompany timelineObject)
        {
            var timelineCompany = _context.TimelineCompany.Update(timelineObject).Entity;
            _context.SaveChanges();
            return timelineCompany;
        }

        public TimelineCompany DeleteTimelineObject(int id)
        {
            var timelineCompany = _context.TimelineCompany.Remove(GetTimelineObject(id)).Entity;
            _context.SaveChanges();
            return timelineCompany;
        }
    }
}
