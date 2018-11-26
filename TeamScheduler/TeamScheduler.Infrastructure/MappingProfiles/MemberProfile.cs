using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Dto;
using TeamScheduler.Core.Entities;

namespace TeamScheduler.Infrastructure.MappingProfiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<AddMemberCommand, Member>();
            CreateMap<Member, MemberDto>();
            CreateMap<UpdateMemberCommand, Member>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.MemberId));
        }
    }
}
