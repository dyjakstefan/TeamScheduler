﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class AddWorkUnitCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public string Description { get; set; }

        public int ScheduleId { get; set; }

        public int MemberId { get; set; }
    }
}
