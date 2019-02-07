using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamScheduler.Core.Dto;
using TeamScheduler.Core.Entities;
using TeamScheduler.Infrastructure.EfContext;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public ScheduleService(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ScheduleDto> Get(int id)
        {
            var schedule = await context.Schedules.SingleOrDefaultAsync(x => x.Id == id);
            return mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<List<ScheduleDto>> GetAllForTeam(int teamId)
        {
            var schedules = await context.Schedules.Where(x => x.TeamId == teamId).ToListAsync();
            return mapper.Map<List<ScheduleDto>>(schedules);
        }

        public async Task<List<DayDto>> GetReport(int scheduleId, string userId)
        {
            var schedule = await context.Schedules.Include(x => x.WorkUnits).SingleOrDefaultAsync(x => x.Id == scheduleId);
            var days = new List<DayDto>();
            var workUnits = schedule.WorkUnits.Where(x => x.Start >= schedule.StartOfWorkingTime && x.End <= schedule.EndOfWorkingTime).ToList();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                var dayDto = new DayDto { Day = day, Hours = new List<HourDto>() };
                var workUnitsForOneDay = workUnits.Where(x => x.DayOfWeek == day).ToList();

                for (int i = schedule.StartOfWorkingTime.Hours; i < schedule.EndOfWorkingTime.Hours; i++)
                {
                    var start = new TimeSpan(i, 0, 0);
                    var end = new TimeSpan(i + 1, 0, 0);
                    var hourDto = new HourDto { Start = start, End = end };
                    var workUnitsForOneHour = workUnitsForOneDay.Where(x => ((x.Start < start && x.End > start) || x.Start >= start && x.Start < end)).ToList();
                    hourDto.IsFullWorkTimeUnit = workUnitsForOneHour.Any(x => x.Start <= start && x.End >= end);
                    workUnitsForOneHour = workUnitsForOneHour.GroupBy(x => x.MemberId).Select(x => x.First()).ToList();
                    hourDto.QuantityOfEmployees = workUnitsForOneHour.Count;
                    dayDto.Hours.Add(hourDto);
                }

                days.Add(dayDto);
            }

            return days;
        }

        public async Task<List<WorkHourDto>> GetReport2(int scheduleId, string userId)
        {
            var schedule = await context.Schedules.Include(x => x.WorkUnits).SingleOrDefaultAsync(x => x.Id == scheduleId);
            var days = new List<DayDto>();
            var workHours = new List<WorkHourDto>();
            var workUnits = schedule.WorkUnits.Where(x => x.Start >= schedule.StartOfWorkingTime && x.End <= schedule.EndOfWorkingTime).ToList();
            for (int i = schedule.StartOfWorkingTime.Hours; i < schedule.EndOfWorkingTime.Hours; i++)
            {
                var start = new TimeSpan(i, 0, 0);
                var end = new TimeSpan(i + 1, 0, 0);
                var workHour = new WorkHourDto { Start = start, End = end };
                foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                {
                    var quantity = workUnits
                        .Where(x => ((x.Start < start && x.End > start) || x.Start >= start && x.Start < end) && x.DayOfWeek == day)
                        .GroupBy(x => x.MemberId)
                        .Select(x => x.First())
                        .Count();
                    switch (day)
                    {
                        case DayOfWeek.Sunday:
                            workHour.QuantityForSunday = quantity;
                            break;
                        case DayOfWeek.Monday:
                            workHour.QuantityForMonday = quantity;
                            break;
                        case DayOfWeek.Tuesday:
                            workHour.QuantityForTuesday = quantity;
                            break;
                        case DayOfWeek.Wednesday:
                            workHour.QuantityForWednesday = quantity;
                            break;
                        case DayOfWeek.Thursday:
                            workHour.QuantityForThursday = quantity;
                            break;
                        case DayOfWeek.Friday:
                            workHour.QuantityForFriday = quantity;
                            break;
                        case DayOfWeek.Saturday:
                            workHour.QuantityForSaturday = quantity;
                            break;
                    }
                }

                workHours.Add(workHour);
            }

            return workHours;
        }
    }
}
