using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Entities;
using TeamScheduler.Core.Enums;
using TeamScheduler.Infrastructure.EfContext;
using Task = System.Threading.Tasks.Task;

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class AddScheduleCommandHandler : AsyncRequestHandler<AddScheduleCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public AddScheduleCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(AddScheduleCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var team = await context.Teams.Include(x => x.Members).SingleOrDefaultAsync(x =>
                x.Id == request.TeamId && x.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager));
            if (team == null)
            {
                throw new Exception("Could not add this schedule.");
            }

            var schedule = mapper.Map<Schedule>(request);
            schedule.CreatedAt = DateTime.UtcNow;
            schedule.UpdatedAt = schedule.CreatedAt;
            context.Schedules.Add(schedule);
            await context.SaveChangesAsync();
        }
    }
}
