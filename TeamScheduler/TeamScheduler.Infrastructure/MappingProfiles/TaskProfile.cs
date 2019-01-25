﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TeamScheduler.Core.Commands;
using TeamScheduler.Core.Dto;
using TeamScheduler.Core.Entities;

namespace TeamScheduler.Infrastructure.MappingProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<AddTaskCommand, Task>();
            CreateMap<UpdateTaskCommand, Task>();
        }
    }
}
