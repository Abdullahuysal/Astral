using Astral.PaymentIntegration.Application.Abstractions.Clock;
using Astral.PaymentIntegration.Application.Abstractions.Exceptions;
using Astral.PaymentIntegration.Application.Abstractions.Messaging;
using Astral.PaymentIntegration.Domain.Abstractions;
using Astral.PaymentIntegration.Domain.Banks;
using Astral.PaymentIntegration.Domain.Payments;

namespace Astral.PaymentIntegration.Application.Payments.CreatePayment
{
    internal sealed class CreatePaymentCommandHandler : ICommandHandler<CreatePaymentCommand, Guid>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IBankRepository _bankRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreatePaymentCommandHandler(
            IPaymentRepository paymentRepository,
            IUnitOfWork unitOfWork,
            IBankRepository bankRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _bankRepository = bankRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var bank = _bankRepository.GetByIdAsync(Guid.NewGuid(), cancellationToken);
            if (bank is null)
            {
                return Result.Failure<Guid>(BankErrors.NotFound);
            }

            try
            {
                var newPayment = Payment.Create(
                    request.MemberId,
                    request.ExternalCode,
                    request.Price,
                    request.Currency,
                    true);

                _paymentRepository.Add(newPayment);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return newPayment.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(PaymentErrors.Overlap);
            }
        }
    }
}
