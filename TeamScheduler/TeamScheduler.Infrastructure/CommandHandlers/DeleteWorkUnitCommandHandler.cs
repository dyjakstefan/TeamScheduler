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
    public class DeleteWorkUnitCommandHandler : AsyncRequestHandler<DeleteWorkUnitCommand>
    {
        private readonly DatabaseContext context;

        public DeleteWorkUnitCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        protected override async Task Handle(DeleteWorkUnitCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var workUnit = await context.WorkUnits.Include(x => x.Schedule.Team)
                .SingleOrDefaultAsync(x => x.Id == request.Id && x.Schedule.Team.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager));
            if (workUnit == null)
            {
                throw new Exception("Could not remove this task.");
            }

            context.WorkUnits.Remove(workUnit);
            await context.SaveChangesAsync();
        }
    }
}
