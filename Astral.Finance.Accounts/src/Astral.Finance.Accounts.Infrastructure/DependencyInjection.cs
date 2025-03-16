using Astral.Finance.Accounts.Application.Abstractions.Clock;
using Astral.Finance.Accounts.Application.Data;
using Astral.Finance.Accounts.Domain.Abstractions;
using Astral.Finance.Accounts.Domain.Accounts;
using Astral.Finance.Accounts.Domain.Customers;
using Astral.Finance.Accounts.Infrastructure.Clock;
using Astral.Finance.Accounts.Infrastructure.Context;
using Astral.Finance.Accounts.Infrastructure.Data;
using Astral.Finance.Accounts.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Astral.Finance.Accounts.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            var connectionString = configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });


            //Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ =>
                new SqlConnectionFactory(connectionString));

            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            return services;
        }
    }
}
