using Astral.Membership.Core.Services;
using Astral.Membership.Core.Shared;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.MemberCommands
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Result<bool>>
    {
        private readonly IMemberService _memberService;
        public CreateMemberCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<Result<bool>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberService.CreateMember(1, request.Name, request.Title, request.Email, request.PhoneNumber, request.Iban, request.ParentMemberId);
            return member != null ? true : Result.Failure<bool>(ApplicationErrors.NotFound("Application Failure", "Member Could Not Be Create"));
        }
    }
}
