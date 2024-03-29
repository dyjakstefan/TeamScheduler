﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamScheduler.Core.Dto
{
    public class WorkHourDto
    {
        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public int QuantityForMonday { get; set; }

        public int QuantityForTuesday { get; set; }

        public int QuantityForWednesday { get; set; }

        public int QuantityForThursday { get; set; }

        public int QuantityForFriday { get; set; }

        public int QuantityForSaturday { get; set; }

        public int QuantityForSunday { get; set; }
    }
}
