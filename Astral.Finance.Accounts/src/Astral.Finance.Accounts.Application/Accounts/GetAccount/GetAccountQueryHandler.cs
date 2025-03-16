using Astral.Finance.Accounts.Application.Abstractions.Messaging;
using Astral.Finance.Accounts.Application.Data;
using Astral.Finance.Accounts.Domain.Abstractions;
using Dapper;

namespace Astral.Finance.Accounts.Application.Accounts.GetAccount
{
    internal sealed class GetAccountQueryHandler : IQueryHandler<GetAccountQuery, AccountResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAccountQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<AccountResponse>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                Select   
                    id AS Id,
                    customer_id AS CustomerId,
                    account_number AS AccountNumber,
                    status AS Status,
                    type AS Type,
                    create_time as CreateTime,
                    update_time AS UpdateTime,
                    amount AS Amount
                FROM Accounts
                WHERE id =@accountId
                """;

            var account = await connection.QueryFirstOrDefaultAsync<AccountResponse>(
                sql,
                new
                {
                    request.AccountId,
                });

            return account;
        }
    }
}
