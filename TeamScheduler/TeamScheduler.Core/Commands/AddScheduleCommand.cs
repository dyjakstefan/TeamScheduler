﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TeamScheduler.Core.Commands
{
    public class AddScheduleCommand : IRequest
    {
        public string ManagerId { get; set; }

        public string Name { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public int TeamId { get; set; }
    }
}