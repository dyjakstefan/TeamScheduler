using System;
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

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public int ScheduleId { get; set; }

        public int MemberId { get; set; }
    }
}
