using Astral.Finance.Accounts.Domain.Abstractions;

namespace Astral.Finance.Accounts.Domain.Customers
{
    public static class CustomerErrors
    {
        public static Error NotFound = new(
            "Customer.NotFound",
            "The customer with the specified identifier was not found");
    }
}
