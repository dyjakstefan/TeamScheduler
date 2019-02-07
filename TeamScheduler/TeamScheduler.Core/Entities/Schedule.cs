using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Abstract;

namespace TeamScheduler.Core.Entities
{
    public class Schedule : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public TimeSpan StartOfWorkingTime { get; set; }

        public TimeSpan EndOfWorkingTime { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual List<WorkUnit> WorkUnits { get; set; }
    }
}
