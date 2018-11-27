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

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class DeleteScheduleCommandHandler : AsyncRequestHandler<DeleteScheduleCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public DeleteScheduleCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var schedule = await context.Schedules.Include(x => x.Team).ThenInclude(x => x.Members).SingleOrDefaultAsync(x =>
                x.Id == request.ScheduleId &&
                x.Team.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager));

            if (schedule == null)
            {
                throw new Exception("Could not remove this schedule.");
            }

            context.Schedules.Remove(schedule);
            await context.SaveChangesAsync();
        }
    }
}
