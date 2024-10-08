using Astral.Membership.Core.Shared;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class CreateUserCommand : IRequest<Result<bool>>
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
