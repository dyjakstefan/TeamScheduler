using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamScheduler.Core.Dto;

namespace TeamScheduler.Infrastructure.Services.Abstract
{
    public interface IWorkUnitService : IService
    {
        Task<List<WorkUnitDto>> GetAll(int scheduleId, DayOfWeek dayOfWeek);
    }
}
