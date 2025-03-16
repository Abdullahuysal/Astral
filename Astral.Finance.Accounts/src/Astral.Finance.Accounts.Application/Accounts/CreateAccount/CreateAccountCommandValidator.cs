using FluentValidation;

namespace Astral.Finance.Accounts.Application.Accounts.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();

            RuleFor(c => c.AccountNumber).NotNull();

            RuleFor(c => c.AccountType).NotEmpty();
        }
    }
}
