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
using TeamScheduler.Core.Enums;
using TeamScheduler.Infrastructure.EfContext;

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class UpdateWorkUnitsListCommandHandler : AsyncRequestHandler<UpdateWorkUnitsListCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UpdateWorkUnitsListCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateWorkUnitsListCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var workUnits = await context.WorkUnits
                .Include(x => x.Schedule)
                .ThenInclude(x => x.Team)
                .Where(x => x.MemberId == request.MemberId && x.ScheduleId == request.ScheduleId && x.Schedule.Team.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager))
                .ToListAsync();

            if (workUnits.Count == 0)
            {
                throw new Exception("Could not update this work units.");
            }

            foreach (var workUnit in workUnits)
            {
                var singleWorkUnit = request.WorkUnits.SingleOrDefault(x => x.Id == workUnit.Id);
                if (singleWorkUnit != null)
                {
                    mapper.Map(singleWorkUnit, workUnit);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
