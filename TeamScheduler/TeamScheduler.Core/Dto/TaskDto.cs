using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Entities;

namespace TeamScheduler.Core.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public int ScheduleId { get; set; }

        public int MemberId { get; set; }
    }
}
