using Astral.Finance.Accounts.Domain.Abstractions;

namespace Astral.Finance.Accounts.Domain.Accounts
{
    public static class AccountErrors
    {
        public static Error NotFound = new(
            "Account.NotFound",
            "The account with the specified identifier was not found");

        public static Error NotClosed = new(
            "Account.NotClosed",
            "The account with the specified identifier is not closed");

        public static Error Overlap = new(
            "Account.Overlap",
            "The current account is overlapping with an existing one");
    }
}
