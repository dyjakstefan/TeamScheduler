using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class DeleteTaskCommand : IRequest
    {
        [JsonIgnore]
        public string ManagerId { get; set; }

        public int TaskId { get; set; }
    }
}
