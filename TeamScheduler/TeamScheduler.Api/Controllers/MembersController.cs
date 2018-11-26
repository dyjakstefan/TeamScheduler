using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamScheduler.Core.Commands;

namespace TeamScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly IMediator mediator;

        public MembersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMemberCommand command)
        {
            //command.ManagerId = User.Identity.Name;
            command.ManagerId = "4";
            await mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMemberCommand command)
        {
            //command.ManagerId = User.Identity.Name;
            command.ManagerId = "4";
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMemberCommand command)
        {
            //command.ManagerId = User.Identity.Name;
            command.ManagerId = "4";
            await mediator.Send(command);
            return Ok();
        }
    }
}
