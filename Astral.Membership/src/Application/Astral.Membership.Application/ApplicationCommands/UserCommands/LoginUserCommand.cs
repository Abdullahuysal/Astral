using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class LoginUserCommand : IRequest<bool>
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
