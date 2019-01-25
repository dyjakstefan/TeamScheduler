using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class DeleteMemberCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public int TeamId { get; set; }

        public int MemberId { get; set; }
    }
}
