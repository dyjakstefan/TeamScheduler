using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Abstract;
using TeamScheduler.Core.Enums;

namespace TeamScheduler.Core.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Role Role { get; set; }

        public virtual List<Member> members { get; set; }
    }
}
