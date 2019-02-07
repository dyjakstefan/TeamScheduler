using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class AddScheduleCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public TimeSpan StartOfWorkingTime { get; set; }

        public TimeSpan EndOfWorkingTime { get; set; }

        public int TeamId { get; set; }
    }
}
