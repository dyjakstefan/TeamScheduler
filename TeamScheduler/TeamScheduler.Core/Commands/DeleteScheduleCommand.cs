using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TeamScheduler.Core.Commands
{
    public class DeleteScheduleCommand : IRequest
    {
        public string ManagerId { get; set; }

        public int ScheduleId { get; set; }
    }
}
