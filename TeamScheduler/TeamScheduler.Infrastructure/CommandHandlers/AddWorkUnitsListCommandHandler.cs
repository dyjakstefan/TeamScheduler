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
    public class AddWorkUnitsListCommandHandler : AsyncRequestHandler<AddWorkUnitsListCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public AddWorkUnitsListCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(AddWorkUnitsListCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var schedule = await context.Schedules.SingleOrDefaultAsync(x => x.Id == request.ScheduleId);
            var team = await context.Teams.Include(x => x.Members).SingleOrDefaultAsync(x =>
                x.Id == schedule.TeamId && x.Members.Any(y => y.UserId == managerId && (y.Title == Title.Manager || y.UserId == schedule.CreatorId)));
            if (team == null || schedule == null)
            {
                throw new Exception("Could not add this work units.");
            }
            var workUnits = mapper.Map<List<WorkUnit>>(request.WorkUnits);
            foreach (var workUnit in workUnits)
            {
                workUnit.MemberId = request.MemberId;
                workUnit.ScheduleId = request.ScheduleId;
            }
            context.WorkUnits.AddRange(workUnits);
            await context.SaveChangesAsync();
        }
    }
}
