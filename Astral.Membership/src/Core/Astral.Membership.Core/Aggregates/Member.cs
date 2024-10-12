namespace Astral.Membership.Core.Aggregates
{
    public record Member
    {
        public Guid Id { get; private set; }
        public Guid? ParentMemberId { get; private set; }
        public long ExternalId { get; private set; }
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsApproved { get; private set; }
        public string Iban { get; private set; }

        public static Member CreateMember(long externalId, string name, string title, string email, string phoneNumber, string iban, Guid? parentMemberId = null)
        {
            return new Member
            {
                Id = Guid.NewGuid(),
                ExternalId = externalId,
                Name = name,
                Title = title,
                Email = email,
                PhoneNumber = phoneNumber,
                Iban = iban,
                ParentMemberId = parentMemberId,
                IsApproved = false,
            };
        }

        public static Member UpdateMember(Member member, string name, string title, string email, string phoneNumber, string iban)
        {
            return member with
            {
                Name = name,
                Title = title,
                Email = email,
                PhoneNumber = phoneNumber,
                Iban = iban,
            };
        }

        public void Approve()
        {
            IsApproved = true;
        }

        public void UpdateContactInfo(string email, string phoneNumber)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        public void UpdateTitle(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public void UpdateIban(string iban)
        {
            Iban = iban ?? throw new ArgumentNullException(nameof(iban));
        }
    }

}
