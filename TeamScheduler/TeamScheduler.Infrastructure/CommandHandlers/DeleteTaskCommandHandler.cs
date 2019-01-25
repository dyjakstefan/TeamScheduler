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
    public class DeleteTaskCommandHandler : AsyncRequestHandler<DeleteTaskCommand>
    {
        private readonly DatabaseContext context;

        public DeleteTaskCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        protected override async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var task = await context.Tasks.Include(x => x.Schedule.Team)
                .SingleOrDefaultAsync(x => x.Id == request.TaskId && x.Schedule.Team.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager));
            if (task == null)
            {
                throw new Exception("Could not remove this task.");
            }

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
    }
}
