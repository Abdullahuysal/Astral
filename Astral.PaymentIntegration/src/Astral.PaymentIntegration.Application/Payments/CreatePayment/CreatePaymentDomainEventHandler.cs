using Astral.PaymentIntegration.Application.Abstractions.Notifications.Email;
using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Domain.Payments.Events;
using MediatR;

namespace Astral.PaymentIntegration.Application.Payments.CreatePayment
{
    internal sealed class CreatePaymentDomainEventHandler : INotificationHandler<PaymentCreateDomainEvent>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IEmailService _emailService;
        public CreatePaymentDomainEventHandler(
            IPaymentRepository paymentRepository,
            IEmailService emailService)
        {
            _paymentRepository = paymentRepository;
            _emailService = emailService;
        }

        public async Task Handle(PaymentCreateDomainEvent notification, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdAsync(notification.paymentId, cancellationToken);

            if (payment == null)
            {
                return;
            }

            await _emailService.SendAsync(
                "",
                "PaymentCreated",
                "Payment created successfully");
        }
    }
}
