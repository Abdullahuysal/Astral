using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;

namespace Astral.Membership.Application.ApplicationServices
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Member> _memberRepository;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _memberRepository = _unitOfWork.GetRepository<Member>();
        }
        public async Task<Member> GetMemberById(Guid memberId)
        {
            return await _memberRepository.FindAsync(x => x.Id == memberId);
        }

        public async Task<Member> GetMemberByName(string name)
        {
            return await _memberRepository.FindAsync(x => x.Name == name);
        }

        public async Task<Member> GetMemberByExternalId(long externalId)
        {
            return await _memberRepository.FindAsync(x => x.ExternalId == externalId);
        }

        public async Task<Member> CreateMember(long externalId, string name, string title, string email, string phoneNumber, string iban, Guid? parentMemberId = null)
        {
            var member = Member.CreateMember(externalId, name, title, email, phoneNumber, iban, parentMemberId);
            _memberRepository.Add(member);
            await _unitOfWork.SaveChangesAsync();
            return member;
        }

        public async Task<Member> UpdateMember(Guid memberId, string name, string title, string email, string phoneNumber, string iban)
        {
            var updatedMember = await _memberRepository.FindAsync(x => x.Id == memberId);
            updatedMember = Member.UpdateMember(updatedMember, name, title, email, phoneNumber, iban);
            _memberRepository.Update(updatedMember);
            await _unitOfWork.SaveChangesAsync();
            return updatedMember;
        }

        public async Task<Member> ApproveMember(Guid memberId)
        {
            var member = await _memberRepository.FindAsync(x => x.Id == memberId);  
            member.Approve();   
            _memberRepository.Update(member);
            await _unitOfWork.SaveChangesAsync();
            return member;
        }
        public async Task<List<Member>> GetMembersByParentMember(Guid parentMemberId)
        {
            var members = await _memberRepository.FindAllAsync(x => x.ParentMemberId == parentMemberId);
            return members.ToList();
        }
    }
}
