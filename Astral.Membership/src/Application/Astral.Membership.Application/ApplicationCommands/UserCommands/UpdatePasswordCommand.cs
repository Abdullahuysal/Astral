using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class UpdatePasswordCommand : IRequest<bool>
    {
        public required string UserName { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}
