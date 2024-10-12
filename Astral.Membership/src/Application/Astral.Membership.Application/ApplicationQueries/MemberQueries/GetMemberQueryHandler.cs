using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Services;
using MediatR;

namespace Astral.Membership.Application.ApplicationQueries.MemberQueries
{
    public class GetMemberQueryHandler : IRequestHandler<GetMemberQuery, Member>
    {
        private readonly IMemberService _memberService;
        public GetMemberQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public Task<Member> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            var member = _memberService.GetMemberById(request.MemberId);
            return member;
        }
    }
}
