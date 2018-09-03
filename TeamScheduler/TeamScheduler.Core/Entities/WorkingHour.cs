using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Abstract;

namespace TeamScheduler.Core.Entities
{
    public class WorkingHour : Entity
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsAccepted { get; set; }

        public virtual Day Day { get; set; }

        public virtual Member Member { get; set; }

    }
}
