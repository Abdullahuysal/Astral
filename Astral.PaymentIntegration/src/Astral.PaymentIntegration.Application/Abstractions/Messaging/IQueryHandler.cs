using Astral.PaymentIntegration.Domain.Abstractions;
using MediatR;

namespace Astral.PaymentIntegration.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> :IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
