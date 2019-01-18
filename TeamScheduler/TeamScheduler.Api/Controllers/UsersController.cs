using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TeamScheduler.Core.Commands;
using TeamScheduler.Infrastructure.Extensions;
using TeamScheduler.Infrastructure.Services;
using TeamScheduler.Infrastructure.Services.Abstract;

namespace TeamScheduler.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserService userService;
        private readonly IMemoryCache cache;

        public UsersController(IMediator mediator, IUserService userService, IMemoryCache cache)
        {
            this.mediator = mediator;
            this.userService = userService;
            this.cache = cache;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            command.TokenId = Guid.NewGuid();
            await mediator.Send(command);
            var jwt = cache.GetJwt(command.TokenId);
            return Ok(jwt);
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            command.TokenId = Guid.NewGuid();
            await mediator.Send(command);
            var jwt = cache.GetJwt(command.TokenId);
            return Ok(jwt);
        }

        [Authorize]
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

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            command.UserId = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }
    }
}