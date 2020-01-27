using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class TimelineContactDTO
    {
        public long TimelineId { get; set; }
        public long ContactId { get; set; }

        public static TimelineContactDTO Of(TimelineContact timeline)
        {
            return new TimelineContactDTO
            {
                TimelineId = timeline.TimelineId,
                ContactId = timeline.ContactId,
            };
        }
    }
}
