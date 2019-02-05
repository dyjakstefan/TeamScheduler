using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Abstract;

namespace TeamScheduler.Core.Entities
{
    public class WorkUnit : Entity
    {
        public string Description { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public int ScheduleId { get; set; }

        public int MemberId { get; set; }

        public virtual Schedule Schedule { get; set; }

        public virtual Member Member { get; set; }
    }
}
