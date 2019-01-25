using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class CreateTeamCommand : IRequest
    {
        public CreateTeamCommand()
        {
        }

        public string Name { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }
}
