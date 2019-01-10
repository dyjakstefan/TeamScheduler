using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace TeamScheduler.Core.Commands
{
    public class LoginCommand : IRequest
    {
        public LoginCommand()
        {
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid TokenId { get; set; }
    }
}
