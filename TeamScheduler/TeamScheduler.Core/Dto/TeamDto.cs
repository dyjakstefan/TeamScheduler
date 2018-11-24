using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Responses;

namespace TeamScheduler.Core.Dto
{
    public class TeamDto
    {
        public string Name { get; set; }

        public UserDto Leader { get; set; }

        public List<UserDto> Members { get; set; }
    }
}
