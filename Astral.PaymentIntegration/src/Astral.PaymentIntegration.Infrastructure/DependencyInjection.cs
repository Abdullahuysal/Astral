using Astral.PaymentIntegration.Application.Abstractions.Clock;
using Astral.PaymentIntegration.Application.Abstractions.Data;
using Astral.PaymentIntegration.Application.Abstractions.Notifications.Email;
using Astral.PaymentIntegration.Domain.Abstractions;
using Astral.PaymentIntegration.Domain.Banks;
using Astral.PaymentIntegration.Domain.Payments;
using Astral.PaymentIntegration.Infrastructure.Clock;
using Astral.PaymentIntegration.Infrastructure.Context;
using Astral.PaymentIntegration.Infrastructure.Data;
using Astral.PaymentIntegration.Infrastructure.Notifications.Email;
using Astral.PaymentIntegration.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Astral.PaymentIntegration.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {


            var connectionString =
                configuration.GetConnectionString("PaymentDatabase") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseCamelCaseNamingConvention();
            });

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IBankRepository, BankRepository>();

            services.AddScoped<IPaymentItemRepository, PaymentItemRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

            SqlMapper.AddTypeHandler(new DateOnlyTpyeHandler());

            return services;
        }
    }
}
