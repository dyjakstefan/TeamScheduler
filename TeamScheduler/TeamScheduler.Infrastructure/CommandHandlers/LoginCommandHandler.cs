using System;
using System.Collections.Generic;
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
    public class LoginCommandHandler : AsyncRequestHandler<LoginCommand>
    {
        private readonly DatabaseContext context;
        private readonly IJwtService jwtService;
        private readonly IEncrypter encrypter;
        private readonly IMemoryCache cache;

        public LoginCommandHandler(DatabaseContext context, IJwtService jwtService, IEncrypter encrypter, IMemoryCache cache)
        {
            this.context = context;
            this.jwtService = jwtService;
            this.encrypter = encrypter;
            this.cache = cache;
        }

        protected override async Task Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == request.Email);
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }

            var hash = encrypter.GetHash(request.Password, user.Salt);
            if (user.Password != hash)
            {
                throw new Exception("Invalid credentials.");
            }

            var jwt = jwtService.CreateToken(user.Id, Role.Admin.ToString());
            cache.SetJwt(request.TokenId, jwt);
        }
    }
}
