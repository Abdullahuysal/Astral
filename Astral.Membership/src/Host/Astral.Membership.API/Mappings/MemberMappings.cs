using Astral.Membership.API.Contracts.Member;
using Astral.Membership.Application.ApplicationCommands.MemberCommands;
using AutoMapper;

namespace Astral.Membership.API.Mappings
{
    public class MemberMappings : Profile
    {
        public MemberMappings()
        {
            CreateMap<CreateMemberRequest, CreateMemberCommand>();
        }
    }
}
