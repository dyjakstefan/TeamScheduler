using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamScheduler.Core.Dto;

namespace TeamScheduler.Infrastructure.Services.Abstract
{
    public interface IScheduleService : IService
    {
        Task<ScheduleDto> Get(int id);

        Task<List<ScheduleDto>> GetAllForTeam(int teamId);

        Task<List<DayDto>> GetReport(int scheduleId, string userId);

        Task<List<WorkHourDto>> GetReport2(int scheduleId, string userId);
    }
}
