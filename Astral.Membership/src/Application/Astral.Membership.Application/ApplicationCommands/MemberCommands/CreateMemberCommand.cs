using Astral.Membership.Core.Shared;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.MemberCommands
{
    public class CreateMemberCommand : IRequest<Result<bool>>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Iban { get; set; }
        public Guid ParentMemberId { get; set; }
    }
}
