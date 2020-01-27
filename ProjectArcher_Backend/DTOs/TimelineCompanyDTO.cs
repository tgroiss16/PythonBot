using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class TimelineCompanyDTO
    {
        public long TimelineId { get; set; }
        public long CompanyId { get; set; }

        public static TimelineCompanyDTO Of(TimelineCompany timeline)
        {
            return new TimelineCompanyDTO
            {
                TimelineId = timeline.TimelineId,
                CompanyId = timeline.CompanyId
            };
        }
    }
}
