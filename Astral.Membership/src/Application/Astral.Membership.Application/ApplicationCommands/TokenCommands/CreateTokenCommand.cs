using Astral.Membership.Core.Common;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.TokenCommands
{
    internal class CreateTokenCommand : IRequest<Response<string>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
