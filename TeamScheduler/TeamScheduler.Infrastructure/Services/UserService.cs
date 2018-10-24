using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamScheduler.Core.Responses;
using TeamScheduler.Infrastructure.EfContext;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UserService(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserDto> GetUser(string email)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == email);
            return user != null ? mapper.Map<UserDto>(user) : null;
        }

    }
}
