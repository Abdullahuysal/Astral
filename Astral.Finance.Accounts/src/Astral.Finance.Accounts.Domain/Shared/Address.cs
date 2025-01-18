namespace Astral.Finance.Accounts.Domain.Shared
{
    public record Address
    {
        public string Street { get; }
        public string City { get; }
        public string Country { get; }
        public string ZipCode { get; }

        public Address(string street, string city, string country, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be empty.", nameof(street));
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.", nameof(city));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be empty.", nameof(country));
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("ZipCode cannot be empty.", nameof(zipCode));

            Street = street.Trim();
            City = city.Trim();
            Country = country.Trim();
            ZipCode = zipCode.Trim();
        }

        public override string ToString() => $"{Street}, {City}, {Country}, {ZipCode}";
    }

}
