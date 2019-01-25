using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;
using TeamScheduler.Core.Enums;

namespace TeamScheduler.Core.Commands
{
    public class UpdateMemberCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public int TeamId { get; set; }

        public int MemberId { get; set; }

        public int Hours { get; set; }

        public Title Title { get; set; }

        public bool IsPartTime { get; set; }
    }
}
 