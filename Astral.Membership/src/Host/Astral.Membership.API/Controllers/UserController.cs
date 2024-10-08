using Astral.Membership.API.Contracts.User.Requests;
using Astral.Membership.API.Extensions;
using Astral.Membership.Application.ApplicationCommands.UserCommands;
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
        public async Task<IResult> UpdatePassword(UpdatePasswordRequest request)
        {
            var command = _mapper.Map<UpdatePasswordCommand>(request);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IResult> Login(string userName, string Password)
        {
            var token = await _userService.LoginAsync(userName, Password);
            return !string.IsNullOrEmpty(token) ? Results.Ok(token) : Results.BadRequest("Invalid username or password");
        }

        [HttpPatch]
        [Route("Logout")]
        public async Task<IResult> Logout(string userName, string token)
        {
            var result = await _userService.LogoutAsync(userName, token);
            return result ? Results.Ok() : Results.BadRequest("Logout failed");
        }

    }
}
