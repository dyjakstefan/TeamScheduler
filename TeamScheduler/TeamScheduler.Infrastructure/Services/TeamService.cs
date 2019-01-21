using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamScheduler.Core.Dto;
using TeamScheduler.Infrastructure.EfContext;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public TeamService(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TeamDto> Get(int id)
        {
            var team = await context.Teams.Include(x => x.Members).SingleOrDefaultAsync(x => x.Id == id);
            return team != null ? mapper.Map<TeamDto>(team) : null;
        }

        public async Task<List<TeamDto>> GetAllForUser(string userId)
        {
            int parsedUserId;
            if (int.TryParse(userId, out parsedUserId))
            {
                var teams = await context.Teams.Include(x => x.Members).Where(x => x.Members.Any(z => z.UserId == parsedUserId)).ToListAsync();
                return mapper.Map<List<TeamDto>>(teams);
            }
            else
            {
                throw new Exception("Could not parse user id.");
            }
        }
    }
}
