using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TeamScheduler.Core.Commands
{
    public class CreateTeamCommand : IRequest
    {
        public CreateTeamCommand()
        {
        }

        public string Name { get; set; }

        public string LeaderId { get; set; }
    }
}
