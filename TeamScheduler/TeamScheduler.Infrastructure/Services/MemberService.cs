using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamScheduler.Core.Dto;
using TeamScheduler.Core.Entities;
using TeamScheduler.Infrastructure.EfContext;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public MemberService(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<MemberDto>> GetAll(int teamId, int scheduleId, string userId)
        {
            int parsedUserId;
            if (int.TryParse(userId, out parsedUserId))
            {
                var members = await context.Members.Include(x => x.WorkUnits).Include(x => x.User).Where(x => x.TeamId == teamId).ToListAsync();
                if (members.Any(x => x.UserId == parsedUserId))
                {
                    var memberList = new List<MemberDto>();
                    foreach (var member in members)
                    {
                        var memberDto = mapper.Map<MemberDto>(member);
                        member.WorkUnits = member.WorkUnits.Where(x => x.ScheduleId == scheduleId).ToList();
                        memberDto.AssignedTime = CalculateAssignedTime(member.WorkUnits);
                        memberList.Add(memberDto);
                    }

                    return memberList;
                }
            }

            throw new Exception("Could not parse user id.");
        }

        public TimeSpan CalculateAssignedTime(List<WorkUnit> workUnits)
        {
            var time = new TimeSpan();
            foreach (var workUnit in workUnits)
            {
                if (workUnit.End > workUnit.Start)
                {
                    time += workUnit.End - workUnit.Start;
                }
                else
                {
                    time += new TimeSpan(0, 24, 0, 0) - workUnit.Start + workUnit.End;
                }
            }

            return time;
        }
    }
}
