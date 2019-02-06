using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamScheduler.Core.Dto;

namespace TeamScheduler.Infrastructure.Services.Abstract
{
    public interface IMemberService : IService
    {
        Task<List<MemberDto>> GetAll(int teamId, int scheduleId, string userId);
    }
}
