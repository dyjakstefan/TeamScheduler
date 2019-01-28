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
    public class WorkUnitService : IWorkUnitService
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public WorkUnitService(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<WorkUnitDto>> GetAll(int scheduleId, DayOfWeek dayOfWeek)
        {
            var tasks = await context.WorkUnits.Where(x => x.ScheduleId == scheduleId && x.DayOfWeek == dayOfWeek)
                .ToListAsync();
            return mapper.Map<List<WorkUnitDto>>(tasks);
        }
    }
}
