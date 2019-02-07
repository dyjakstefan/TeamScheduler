using System;
using System.Collections.Generic;
using System.Text;

namespace TeamScheduler.Core.Dto
{
    public class DayDto
    {
        public DayOfWeek Day { get; set; }

        public List<HourDto> Hours { get; set; }
    }
}
