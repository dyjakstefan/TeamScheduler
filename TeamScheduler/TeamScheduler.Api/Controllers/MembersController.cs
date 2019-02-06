using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamScheduler.Core.Commands;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMemberService memberService;

        public MembersController(IMediator mediator, IMemberService memberService)
        {
            this.mediator = mediator;
            this.memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMemberCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMemberCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMemberCommand command)
        {
            command.ManagerId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{teamId}/{scheduleId}")]
        public async Task<IActionResult> Get(int teamId, int scheduleId)
        {
            var userId = User.Identity.Name;
            var members = await memberService.GetAll(teamId, scheduleId, userId);
            return Ok(members);
        }
    }
}
