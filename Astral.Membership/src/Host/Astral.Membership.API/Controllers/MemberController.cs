using Astral.Membership.API.Contracts.Member;
using Astral.Membership.Application.ApplicationCommands.MemberCommands;
using Astral.Membership.Application.ApplicationQueries.MemberQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Astral.Membership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MemberController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IResult> GetMember(Guid memberId)
        {
            var query = new GetMemberQuery(memberId);
            var member = await _mediator.Send(query);
            return member != null ? Results.Ok(member) : Results.NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IResult> Create(CreateMemberRequest request)
        {
            var command = _mapper.Map<CreateMemberCommand>(request);
            command.ParentMemberId = Guid.NewGuid();
            
            var result = await _mediator.Send(command);
            return result != null ? Results.Ok(result) : Results.BadRequest();
        }
    }
}
