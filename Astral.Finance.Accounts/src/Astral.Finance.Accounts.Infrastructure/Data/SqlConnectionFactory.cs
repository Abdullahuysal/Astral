﻿using Astral.Finance.Accounts.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Astral.Finance.Accounts.Infrastructure.Data
{
    internal sealed class SqlConnectionFactory : ISqlConnectionFactory
    {

        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection;
        }
    }
}
