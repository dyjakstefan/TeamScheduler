using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;

namespace TeamScheduler.Core.Commands
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserCommand()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public Guid TokenId { get; set; }
    }
}
