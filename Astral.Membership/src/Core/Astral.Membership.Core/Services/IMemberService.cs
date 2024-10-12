using Astral.Membership.Core.Aggregates;

namespace Astral.Membership.Core.Services
{
    public interface IMemberService
    {
        Task<Member> GetMemberById(Guid memberId);
        Task<Member> GetMemberByName(string name);
        Task<Member> GetMemberByExternalId(long externalId);
        Task<Member> CreateMember(long externalId, string name, string title, string email, string phoneNumber, string iban, Guid? parentMemberId = null);
        Task<Member> UpdateMember(Guid memberId, string name, string title, string email, string phoneNumber, string iban);
        Task<Member> ApproveMember(Guid memberId);
        Task<List<Member>> GetMembersByParentMember(Guid parentMemberId);

    }
}
