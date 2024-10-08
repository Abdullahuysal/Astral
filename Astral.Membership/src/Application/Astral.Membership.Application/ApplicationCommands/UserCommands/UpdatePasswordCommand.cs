using Astral.Membership.Core.Shared;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class UpdatePasswordCommand : IRequest<Result<bool>>
    {
        public required string UserName { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}
