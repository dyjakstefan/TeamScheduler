using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class UpdateWorkUnitsListCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public int ScheduleId { get; set; }

        public int MemberId { get; set; }

        public DayOfWeek Day { get; set; }

        public List<UpdateWorkUnitCommand> WorkUnits { get; set; }
    }
}
