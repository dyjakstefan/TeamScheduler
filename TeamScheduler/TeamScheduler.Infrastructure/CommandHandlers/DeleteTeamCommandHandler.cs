using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamScheduler.Core.Commands;
using TeamScheduler.Infrastructure.EfContext;

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class DeleteTeamCommandHandler : AsyncRequestHandler<DeleteTeamCommand>
    {
        private readonly DatabaseContext context;

        public DeleteTeamCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        protected override async Task Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await context.Teams.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (team != null)
            {
                context.Teams.Remove(team);
                await context.SaveChangesAsync();
            }
        }
    }
}
