﻿using System;
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

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public TimeSpan StartOfWorkingTime { get; set; }

        public TimeSpan EndOfWorkingTime { get; set; }

        public string Description { get; set; }
    }
}
