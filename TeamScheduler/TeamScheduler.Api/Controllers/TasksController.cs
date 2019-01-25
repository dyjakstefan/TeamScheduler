using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamScheduler.Core.Commands;
using TeamScheduler.Infrastructure.Services;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly IMediator mediator;
        private readonly ITaskService taskService;

        public TasksController(IMediator mediator, ITaskService taskService)
        {
            this.taskService = taskService;
            this.mediator = mediator;
        }

        [Route("{scheduleId}/{dayOfWeek}")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int scheduleId, DayOfWeek dayOfWeek)
        {
            var tasks = await taskService.GetAll(scheduleId, dayOfWeek);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTaskCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Add([FromBody] UpdateTaskCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTaskCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }
    }
}