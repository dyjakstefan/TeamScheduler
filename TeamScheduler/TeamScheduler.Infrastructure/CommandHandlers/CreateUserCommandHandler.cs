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
using TeamScheduler.Infrastructure.EfContext;

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await context.Users.AnyAsync(x => x.Email == request.Email))
            {
                return; 
            }

            var user = mapper.Map<User>(request);
            context.Add(user);
            await context.SaveChangesAsync();
        }
    }
}
