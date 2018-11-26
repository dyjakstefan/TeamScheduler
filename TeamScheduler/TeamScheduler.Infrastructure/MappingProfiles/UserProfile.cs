using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Dto;
using TeamScheduler.Core.Entities;

namespace TeamScheduler.Infrastructure.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<User, UserDto>();
        }
    }
}
