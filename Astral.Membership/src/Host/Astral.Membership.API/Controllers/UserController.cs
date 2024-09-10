using Astral.Membership.API.Contracts.User.Requests;
using Astral.Membership.API.Contracts.User.Responses;
using Astral.Membership.Application.ApplicationCommands.UserCommands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var command = _mapper.Map<CreateUserCommand>(request);
            var commandResponse = await _mediator.Send(command);
            var newUser = _mapper.Map<CreateUserResponse>(commandResponse);
            return Ok(newUser);
        }
    }
}
