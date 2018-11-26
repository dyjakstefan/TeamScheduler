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
    public class UpdateMemberCommandHandler : AsyncRequestHandler<UpdateMemberCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UpdateMemberCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var team = await context.Teams.SingleOrDefaultAsync(x =>
                x.Id == request.TeamId && x.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager));
            if (team != null)
            {
                var member = await context.Members.SingleOrDefaultAsync(x => x.Id == request.MemberId);
                if (member != null)
                {
                    var newMember = mapper.Map(request, member);
                    context.Members.Update(newMember);
                    await context.SaveChangesAsync();
                    return;
                }
            }

            throw new Exception("Could not add this member.");
        }
    }
}
