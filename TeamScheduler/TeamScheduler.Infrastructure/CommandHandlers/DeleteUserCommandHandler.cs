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

        protected async override Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}