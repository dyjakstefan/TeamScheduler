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

        public string Password { get; set; }

        public string Salt { get; set; }

        public Role Role { get; set; }

        public virtual List<Member> Members { get; set; }

        public void SetPassword(string hash)
        {
            this.Password = hash;
        }

        public void SetSalt(string salt)
        {
            this.Salt = salt;
        }
    }
}
