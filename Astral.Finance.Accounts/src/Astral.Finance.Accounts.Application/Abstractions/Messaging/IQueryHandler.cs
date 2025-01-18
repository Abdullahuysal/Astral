using Astral.Finance.Accounts.Domain.Abstractions;
using MediatR;

namespace Astral.Finance.Accounts.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
