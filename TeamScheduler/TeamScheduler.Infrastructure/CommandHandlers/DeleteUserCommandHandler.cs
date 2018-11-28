using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamScheduler.Core.Commands;
using TeamScheduler.Infrastructure.EfContext;

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly DatabaseContext context;

        public DeleteUserCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (!int.TryParse(request.UserId, out var managerId))
            {
                throw new Exception("Could not parse user id.");
            }

            var user = await context.Users.SingleOrDefaultAsync(x => x.Id == managerId);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}