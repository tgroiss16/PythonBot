using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class TimelineCompanyDTO
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
        public DateTime Timestamp { get; set; }

        public static TimelineCompanyDTO Of(TimelineCompany timeline)
        {
            return new TimelineCompanyDTO
            {
                Id = timeline.Id,
                CompanyId = timeline.CompanyId,
                Title = timeline.Title,
                Note = timeline.Note,
                Attachment = timeline.Attachment,
                FileName = timeline.FileName,
                Timestamp = timeline.Timestamp
            };
        }
    }
}
