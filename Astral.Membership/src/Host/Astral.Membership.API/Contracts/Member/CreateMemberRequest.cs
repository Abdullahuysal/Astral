namespace Astral.Membership.API.Contracts.Member
{
    public class CreateMemberRequest
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Iban { get; set; }
    }
}
