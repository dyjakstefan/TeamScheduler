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
    public class WorkUnitController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IWorkUnitService _workUnitService;

        public WorkUnitController(IMediator mediator, IWorkUnitService workUnitService)
        {
            this._workUnitService = workUnitService;
            this.mediator = mediator;
        }

        [HttpGet("{scheduleId}/{dayOfWeek}")]
        public async Task<IActionResult> GetAll(int scheduleId, DayOfWeek dayOfWeek)
        {
            var workUnits = await _workUnitService.GetAll(scheduleId, dayOfWeek);
            return Ok(workUnits);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddWorkUnitCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpPost("list")]
        public async Task<IActionResult> AddList([FromBody] AddWorkUnitsListCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWorkUnitCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut("list")]
        public async Task<IActionResult> UpdateList([FromBody] UpdateWorkUnitsListCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteWorkUnitCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }
    }
}