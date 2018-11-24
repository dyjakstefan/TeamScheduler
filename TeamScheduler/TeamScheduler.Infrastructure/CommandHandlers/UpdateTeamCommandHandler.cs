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
    public class UpdateTeamCommandHandler : AsyncRequestHandler<UpdateTeamCommand>
    {
        private readonly DatabaseContext context;

        public UpdateTeamCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        protected override async Task Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await context.Teams.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (team != null)
            {
                team.Name = request.Name;
                await context.SaveChangesAsync();
            }
        }
    }
}
