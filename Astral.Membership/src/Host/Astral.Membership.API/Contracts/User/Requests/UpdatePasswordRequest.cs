namespace Astral.Membership.API.Contracts.User.Requests
{
    public class UpdatePasswordRequest
    {
        public required string UserName { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }

    }
}
