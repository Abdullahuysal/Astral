using Astral.Finance.Accounts.Application.Abstractions.Clock;
using Astral.Finance.Accounts.Application.Abstractions.Messaging;
using Astral.Finance.Accounts.Application.Exceptions;
using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Domain.Accounts;
using Astral.Finance.Accounts.Domain.Customers;

namespace Astral.Finance.Accounts.Application.Accounts.CreateAccount
{
    internal sealed class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateAccountCommandHandler(
            IAccountRepository accountRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);

            if (customer is null)
            {
                return Result.Failure<Guid>(CustomerErrors.NotFound);
            }

            try
            {
                Account newAccount = Account.Create(
                    request.CustomerId,
                    request.AccountNumber,
                    request.AccountType,
                    _dateTimeProvider.UtcNow,
                    _dateTimeProvider.UtcNow
                );

                _accountRepository.Add(newAccount);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return newAccount.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(AccountErrors.Overlap);
            }
        }
    }
}
