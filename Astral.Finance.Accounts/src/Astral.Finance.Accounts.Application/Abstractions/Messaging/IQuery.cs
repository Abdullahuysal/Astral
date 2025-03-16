using Astral.Finance.Accounts.Domain.Abstractions;
using MediatR;

namespace Astral.Finance.Accounts.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
