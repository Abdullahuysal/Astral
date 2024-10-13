namespace Astral.PaymentIntegration.Core.Enums
{
    public record Currency
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        private Currency(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public static readonly Currency USD = new Currency("USD", "United States Dollar");
        public static readonly Currency EUR = new Currency("EUR", "Euro");
        public static readonly Currency GBP = new Currency("GBP", "British Pound");
        public static readonly Currency TRY = new Currency("TRY", "Turkish Lira");

        private static readonly Dictionary<string, Currency> _currenciesByCode = new Dictionary<string, Currency>
        {
            { USD.Code, USD },
            { EUR.Code, EUR },
            { GBP.Code, GBP },
            { TRY.Code, TRY }
        };

        private static readonly Dictionary<string, Currency> _currenciesByName = new Dictionary<string, Currency>
        {
            { USD.Name, USD },
            { EUR.Name, EUR },
            { GBP.Name, GBP },
            { TRY.Name, TRY }
        };

        public static Currency GetCurrencyByCode(string code)
        {
            if (_currenciesByCode.TryGetValue(code, out var currency))
            {
                return currency;
            }
            throw new ArgumentException("Invalid currency code");
        }

        public static Currency GetCurrencyByName(string name)
        {
            if (_currenciesByName.TryGetValue(name, out var currency))
            {
                return currency;
            }
            throw new ArgumentException("Invalid currency name");
        }
    }
}
