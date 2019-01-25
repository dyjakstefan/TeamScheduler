using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class UpdateScheduleCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public int ScheduleId { get; set; }

        public string Name { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }
    }
}
