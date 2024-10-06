using Astral.Membership.API.Contracts.User.Requests;
using Astral.Membership.API.Contracts.User.Responses;
using Astral.Membership.Application.ApplicationCommands.UserCommands;
using Astral.Membership.Core.Aggregates;
using AutoMapper;

namespace Astral.Membership.API.Mappings
{
    public class UserMappings:Profile
    {
        public UserMappings()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<UpdatePasswordRequest, UpdatePasswordCommand>();
            CreateMap<User, CreateUserResponse>();
        }
    }
}
