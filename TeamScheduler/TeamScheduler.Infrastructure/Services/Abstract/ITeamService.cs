using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamScheduler.Core.Dto;

namespace TeamScheduler.Infrastructure.Services.Abstract
{
    public interface ITeamService : IService
    {
        Task<TeamDto> Get(int id);

        Task<List<TeamDto>> GetAll();
    }
}
