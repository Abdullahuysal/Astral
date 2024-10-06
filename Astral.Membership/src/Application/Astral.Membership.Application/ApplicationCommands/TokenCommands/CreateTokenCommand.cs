using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.TokenCommands
{
    internal class CreateTokenCommand : IRequest<string>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
