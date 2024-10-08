using Astral.Membership.Core.Shared;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.TokenCommands
{
    internal class CreateTokenCommand : IRequest<Result<string>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
