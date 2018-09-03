using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Abstract;

namespace TeamScheduler.Core.Entities
{
    public class Day : Entity
    {
        public bool IsAccepted { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public virtual Schedule Schedule { get; set; }

        public virtual List<WorkingHour> WorkingHours { get; set; }
    }
}
