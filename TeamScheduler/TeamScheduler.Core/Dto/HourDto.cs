using System;
using System.Collections.Generic;
using System.Text;

namespace TeamScheduler.Core.Dto
{
    public class HourDto
    {
        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public int QuantityOfEmployees { get; set; }

        public bool IsFullWorkTimeUnit { get; set; }
    }
}
