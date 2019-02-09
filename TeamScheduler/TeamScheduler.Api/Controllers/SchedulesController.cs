using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamScheduler.Core.Commands;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IScheduleService scheduleService;

        public SchedulesController(IMediator mediator, IScheduleService scheduleService)
        {
            this.mediator = mediator;
            this.scheduleService = scheduleService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddScheduleCommand command)
        {
            command.UserId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteScheduleCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateScheduleCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int scheduleId)
        {
            var schedule = await scheduleService.Get(scheduleId);
            return Ok(schedule);
        }

        [Route("all/{teamId}")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int teamId)
        {
            var schedules = await scheduleService.GetAllForTeam(teamId);
            return Ok(schedules);
        }

        [HttpGet("report/{scheduleId}")]
        public async Task<IActionResult> GetReport(int scheduleId)
        {
            var userId = User.Identity.Name;
            var days = await scheduleService.GetReport(scheduleId, userId);
            return Ok(days);
        }

        [HttpGet("report2/{scheduleId}")]
        public async Task<IActionResult> GetReport2(int scheduleId)
        {
            var userId = User.Identity.Name;
            var days = await scheduleService.GetReport2(scheduleId, userId);
            return Ok(days);
        }
    }
}