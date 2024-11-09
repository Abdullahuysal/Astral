using Astral.PaymentIntegration.Application.Abstractions.Data;
using Astral.PaymentIntegration.Application.Abstractions.Messaging;
using Astral.PaymentIntegration.Domain.Abstractions;
using Dapper;

namespace Astral.PaymentIntegration.Application.Payments.GetPayment
{
    internal sealed class GetPaymentQueryHandler : IQueryHandler<GetPaymentQuery, PaymentResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPaymentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<PaymentResponse>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                 Select
                     id AS Id,
                     memberId AS MemberId,
                     externalCode AS ExternalCode
                     createTime AS CreateTime
                     updateTime AS UpdateTime
                     price AS Price
                     currency AS Currency
                     status AS Status
                FROM Payments
                WHERE id=@PaymentId
                """;

            var payment = await connection.QueryFirstOrDefaultAsync<PaymentResponse>(
                sql,
                new
                {
                    request.paymentId
                });

            return payment;
        }
    }
}
