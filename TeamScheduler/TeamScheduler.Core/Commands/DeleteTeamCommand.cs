using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TeamScheduler.Core.Commands
{
    public class DeleteTeamCommand : IRequest
    {
        public DeleteTeamCommand()
        {
            
        }

        public int TeamId { get; set; }
    }
}
