using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Entities;
using TeamScheduler.Core.Enums;
using TeamScheduler.Infrastructure.EfContext;
using Task = System.Threading.Tasks.Task;

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class AddMemberCommandHandler : AsyncRequestHandler<AddMemberCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public AddMemberCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.ManagerId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var team = await context.Teams.Include(x => x.Members).SingleOrDefaultAsync(x =>
                x.Id == request.TeamId && x.Members.Any(y => y.UserId == managerId && y.Title == Title.Manager));
            if (team != null)
            {
                var user = await context.Users.SingleOrDefaultAsync(x => x.Email == request.Email);
                if (team.Members.All(x => x.Id != user.Id))
                {
                    var member = mapper.Map<Member>(request);
                    member.UserId = user.Id;
                    context.Members.Add(member);
                    await context.SaveChangesAsync();
                    return;
                }
            }

            throw new Exception("Could not add this member.");
        }
    }
}
