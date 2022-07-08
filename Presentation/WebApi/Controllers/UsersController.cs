using Application.Features.Commands.AppUser.GoogleLogin;
using Application.Features.Commands.AppUser.UserAdd;
using Application.Features.Commands.AppUser.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;
        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost("add")]
        public async Task<IActionResult> UserAdd(UserAddCommandRequest request)
        {
            var result = await mediator.Send(request);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginCommandRequest request)
        {
            var result = await mediator.Send(request);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("googleLogin")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

    }
}
