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
    public class UpdateWorkUnitCommandHandler : AsyncRequestHandler<UpdateWorkUnitCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UpdateWorkUnitCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateWorkUnitCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var workUnit = await context.WorkUnits.Include(x => x.Schedule.Team)
                .SingleOrDefaultAsync(x => x.Id == request.TaskId && x.Schedule.Team.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager));
            if (workUnit == null)
            {
                throw new Exception("Could not update this task.");
            }

            mapper.Map(request, workUnit);
            await context.SaveChangesAsync();
        }
    }
}
