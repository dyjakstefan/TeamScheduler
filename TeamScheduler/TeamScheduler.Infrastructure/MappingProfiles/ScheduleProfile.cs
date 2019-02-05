using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Dto;
using TeamScheduler.Core.Entities;

namespace TeamScheduler.Infrastructure.MappingProfiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<AddScheduleCommand, Schedule>();
            CreateMap<UpdateScheduleCommand, Schedule>();
            CreateMap<Schedule, ScheduleDto>();
        }
    }
}
