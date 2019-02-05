using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class UpdateWorkUnitCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }
    }
}
