using System;
using System.Linq;
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
    public class DeleteMemberCommandHandler : AsyncRequestHandler<DeleteMemberCommand>
    {
        private readonly DatabaseContext context;

        public DeleteMemberCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        protected override async Task Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            if (await context.Teams.AnyAsync(x =>
                x.Id == request.TeamId && x.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager)))
            {
                var member = await context.Members.SingleOrDefaultAsync(x => x.Id == request.MemberId);
                context.Members.Remove(member);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Could not add this member.");
            }
        }
    }
}
