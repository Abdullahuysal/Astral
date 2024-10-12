using Astral.Membership.Core.Aggregates;
using MediatR;

namespace Astral.Membership.Application.ApplicationQueries.MemberQueries
{
    public class GetMemberQuery : IRequest<Member>
    {
        public Guid MemberId { get; set; }
        public GetMemberQuery(Guid memberId)
        {
            MemberId = memberId;
        }
    }
}
