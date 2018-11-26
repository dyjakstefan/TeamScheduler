using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Dto;
using TeamScheduler.Core.Entities;

namespace TeamScheduler.Infrastructure.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<CreateTeamCommand, Team>();
            CreateMap<Team, TeamDto>();
        }
    }
}
