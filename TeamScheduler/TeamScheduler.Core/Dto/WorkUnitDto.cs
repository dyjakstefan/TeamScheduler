using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Entities;

namespace TeamScheduler.Core.Dto
{
    public class WorkUnitDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public int ScheduleId { get; set; }

        public int MemberId { get; set; }
    }
}
