﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class DeleteScheduleCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public int ScheduleId { get; set; }
    }
}
