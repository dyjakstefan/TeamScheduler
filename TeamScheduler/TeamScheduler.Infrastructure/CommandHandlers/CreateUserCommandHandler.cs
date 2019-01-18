using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Entities;
using TeamScheduler.Core.Enums;
using TeamScheduler.Infrastructure.EfContext;
using TeamScheduler.Infrastructure.Extensions;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Infrastructure.CommandHandlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private readonly IEncrypter encrypter;
        private readonly IJwtService jwtService;
        private readonly IMemoryCache cache;

        public CreateUserCommandHandler(DatabaseContext context, IMapper mapper, IEncrypter encrypter, IJwtService jwtService, IMemoryCache cache)
        {
            this.context = context;
            this.mapper = mapper;
            this.encrypter = encrypter;
            this.jwtService = jwtService;
            this.cache = cache;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await context.Users.AnyAsync(x => x.Email == request.Email))
            {
                throw new Exception("User with that email already exists.");
            }

            var salt = encrypter.GetSalt(request.Password);
            var hash = encrypter.GetHash(request.Password, salt);
            var user = mapper.Map<User>(request);
            user.SetPassword(hash);
            user.SetSalt(salt);
            context.Add(user);
            await context.SaveChangesAsync();
            var jwt = jwtService.CreateToken(user.Id, Role.Admin.ToString());
            cache.SetJwt(request.TokenId, jwt);
        }
    }
}
