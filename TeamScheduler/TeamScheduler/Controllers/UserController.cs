using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamScheduler.Core.Commands;
using TeamScheduler.Infrastructure.Services;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserService userService;

        public UserController(IMediator mediator, IUserService userService)
        {
            this.mediator = mediator;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string email)
        {
            var user = await userService.GetUser(email);
            if (user != null)
            {
                return Ok(user);
            }

            return NoContent();
        }
    }
}