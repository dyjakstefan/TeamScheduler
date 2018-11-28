using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TeamScheduler.Core.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public string UserId { get; set; }
    }
}