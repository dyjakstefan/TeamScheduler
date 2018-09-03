using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Abstract;
using TeamScheduler.Core.Enums;

namespace TeamScheduler.Core.Entities
{
    public class Member : Entity
    {
        public int Hours { get; set; }

        public Title Title { get; set; }

        public bool IsPartTime { get; set; }

        public virtual User User { get; set; }

        public virtual Team Team { get; set; }

        public virtual List<WorkingHour> WorkingHours { get; set; }
    }
}
