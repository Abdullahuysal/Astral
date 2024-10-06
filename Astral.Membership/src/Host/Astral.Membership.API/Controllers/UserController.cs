using Astral.Membership.API.Contracts.User.Requests;
using Astral.Membership.Application.ApplicationCommands.UserCommands;
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

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
            {
                return Ok(new { Message = "Password updated successfully" });
            }
            else
            {
                return BadRequest(new { Message = "Password update failed" });
            }
        }

    }
}
