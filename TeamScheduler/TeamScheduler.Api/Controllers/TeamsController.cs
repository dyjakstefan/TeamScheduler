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
    public class TeamsController : Controller
    {
        private readonly IMediator mediator;
        private readonly ITeamService teamService;

        public TeamsController(IMediator mediator, ITeamService teamService)
        {
            this.mediator = mediator;
            this.teamService = teamService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeamCommand command)
        {
            command.UserId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTeamCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTeamCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await teamService.GetAllForUser(User.Identity.Name);
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await teamService.Get(id);
            return Ok(team);
        }
    }
}