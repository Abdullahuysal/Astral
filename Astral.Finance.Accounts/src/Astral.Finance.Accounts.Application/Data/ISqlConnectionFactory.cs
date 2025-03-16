using System.Data;

namespace Astral.Finance.Accounts.Application.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
