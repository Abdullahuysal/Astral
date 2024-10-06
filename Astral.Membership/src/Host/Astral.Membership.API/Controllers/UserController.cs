using Astral.Membership.API.Contracts.User.Requests;
using Astral.Membership.Application.ApplicationCommands.UserCommands;
using Astral.Membership.Core.Common;
using Astral.Membership.Core.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Astral.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMediator mediator, IMapper mapper, IUserService userService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var command = _mapper.Map<CreateUserCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
        {
            var command = _mapper.Map<UpdatePasswordCommand>(request);
            var result = await _mediator.Send(command);
            if (result)
                return Ok(new Response<string>(true, "Password updated successfully", string.Empty));
            else
                return BadRequest(new Response<string>(false, "Password update failed", string.Empty));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string userName, string Password)
        {
            var token = await _userService.LoginAsync(userName, Password);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new Response<string>(false, "Invalid username or password", string.Empty));
            }

            return Ok(new Response<string>(true, string.Empty, token));
        }

        [HttpPatch]
        [Route("Logout")]
        public async Task<IActionResult> Logout(string userName, string token)
        {
            var result = await _userService.LogoutAsync(userName, token);
            if (!result)
            {
                return BadRequest(new Response<string>(false, "Logout failed", string.Empty));
            }

            return Ok(new Response<string>(true, "Logout successful", string.Empty));
        }

    }
}
