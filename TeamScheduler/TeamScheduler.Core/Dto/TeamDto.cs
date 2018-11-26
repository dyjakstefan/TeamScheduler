using System;
using System.Collections.Generic;
using System.Text;

namespace TeamScheduler.Core.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<MemberDto> Members { get; set; }
    }
}
