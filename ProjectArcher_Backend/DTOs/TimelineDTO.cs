using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.DTOs
{
    public class TimelineDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
        public DateTime Timestamp { get; set; }

        public static TimelineDTO Of (Timeline timeline)
        {
            return new TimelineDTO
            {
                Id = timeline.Id,
                Title = timeline.Title,
                Note = timeline.Note,
                Attachment = timeline.Attachment,
                FileName = timeline.FileName,
                Timestamp = timeline.Timestamp
            };
        }
    }
}
