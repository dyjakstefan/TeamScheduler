using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Enums;

namespace TeamScheduler.Core.Dto
{
    public class MemberDto
    {
        public int Id { get; set; }

        public int Hours { get; set; }

        public Title Title { get; set; }

        public bool IsPartTime { get; set; }

        public UserDto User { get; set; }

        public int TeamId { get; set; }

        public TimeSpan AssignedTime { get; set; }
    }
}
