using Astral.Finance.Transactions.Application.Abstractions.Messaging;
using Astral.Finance.Transactions.Domain.Abstractions;

namespace Astral.Finance.Transactions.Application.Transactions.CreateTransaction
{
    internal sealed class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTransactionCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Result<Guid>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
