using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamScheduler.Core.Dto;
using TeamScheduler.Infrastructure.EfContext;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public ScheduleService(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ScheduleDto> Get(int id)
        {
            var schedule = await context.Schedules.SingleOrDefaultAsync(x => x.Id == id);
            return mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<List<ScheduleDto>> GetAllForTeam(int teamId)
        {
            var schedules = await context.Schedules.Where(x => x.TeamId == teamId).ToListAsync();
            return mapper.Map<List<ScheduleDto>>(schedules);
        }
    }
}
