using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TeamScheduler.Core.Commands
{
    public class DeleteMemberCommand : IRequest
    {
        public string ManagerId { get; set; }

        public int TeamId { get; set; }

        public int MemberId { get; set; }
    }
}
