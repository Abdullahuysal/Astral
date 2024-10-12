using Astral.Membership.Application.ApplicationServices;
using Astral.Membership.Core.Shared;
using MediatR;
using System.Reflection;

namespace Astral.Membership.Application.ApplicationCommands.MemberCommands
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Result<bool>>
    {
        private readonly MemberService _memberService;
        public CreateMemberCommandHandler(MemberService memberService)
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
