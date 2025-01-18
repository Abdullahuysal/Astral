using Astral.Finance.Accounts.Application.Abstractions.Messaging;
using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Domain.Accounts;

namespace Astral.Finance.Accounts.Application.Accounts.CreateAccount
{
    internal sealed class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand, Guid>
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountCommandHandler(
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork
            )
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {

            return Guid.NewGuid();
        }
    }
}
