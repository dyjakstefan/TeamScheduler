using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TeamScheduler.Core.Commands
{
    public class UpdateTeamCommand : IRequest
    {
        public UpdateTeamCommand()
        {
            
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
