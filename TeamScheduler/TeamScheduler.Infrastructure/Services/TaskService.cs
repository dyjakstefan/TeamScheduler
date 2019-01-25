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
    public class TaskService : ITaskService
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public TaskService(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<TaskDto>> GetAll(int scheduleId, DayOfWeek dayOfWeek)
        {
            var tasks = await context.Tasks.Where(x => x.ScheduleId == scheduleId && x.DayOfWeek == dayOfWeek)
                .ToListAsync();
            return mapper.Map<List<TaskDto>>(tasks);
        }
    }
}
