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
    public class UpdateScheduleCommandHandler : AsyncRequestHandler<UpdateScheduleCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UpdateScheduleCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var schedule = await context.Schedules.SingleOrDefaultAsync(x =>
                x.Id == request.Id &&
                x.Team.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager));
            if (schedule == null)
            {
                throw new Exception("Could not update this schedule.");
            }

            schedule = mapper.Map(request, schedule);
            schedule.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
        }
    }
}
