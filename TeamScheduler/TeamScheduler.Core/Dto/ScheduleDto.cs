using System;
using System.Collections.Generic;
using System.Text;

namespace TeamScheduler.Core.Dto
{
    public class ScheduleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public TimeSpan StartOfWorkingTime { get; set; }

        public TimeSpan EndOfWorkingTime { get; set; }

        public int CreatorId { get; set; }

        public int TeamId { get; set; }
    }
}
