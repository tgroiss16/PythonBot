using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public interface ITimelineService
    {
        Timeline AddTimelineObject(Timeline timelineObject);
        Timeline GetTimelineObject(int id);
        Timeline UpdateTimelineObject(Timeline timelineObject);
        Timeline DeleteTimelineObject(int id);
    }
}
