using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Entities;
using TeamScheduler.Infrastructure.EfContext;

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class CreateTeamCommandHandler : AsyncRequestHandler<CreateTeamCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public CreateTeamCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = mapper.Map<Team>(request);
            context.Teams.Add(team);
            await context.SaveChangesAsync();
        }
    }
}
