using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public interface ICompanyTimelineService
    {
        TimelineCompany AddTimelineObject(TimelineCompany timelineObject);
        TimelineCompany GetTimelineObject(int id);
        List<TimelineCompany> GetTimelineObjects(int companyId);
        TimelineCompany UpdateTimelineObject(TimelineCompany timelineObject);
        TimelineCompany DeleteTimelineObject(int id);
    }
}
