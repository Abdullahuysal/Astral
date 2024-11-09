using FluentValidation;

namespace Astral.PaymentIntegration.Application.Payments.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(c => c.MemberId).NotEmpty();

            RuleFor(c =>c.ExternalCode).NotEmpty(); 

            RuleFor(c =>c.Currency).NotEmpty();

            RuleFor(c =>c.Price).NotEmpty();

            RuleFor(c =>c.Price.Amount).GreaterThan(0);

        }
    }
}
