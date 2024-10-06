namespace Astral.Membership.API.Contracts.User.Requests
{
    public class CreateUserRequest
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
