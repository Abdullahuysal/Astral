using Astral.PaymentIntegration.Domain.Abstractions;
using MediatR;

namespace Astral.PaymentIntegration.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
