using Astral.PaymentIntegration.Application.Abstractions.Behaviors;
using Astral.PaymentIntegration.Domain.Payments;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Astral.PaymentIntegration.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);

                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddTransient<PaymentService>();
            return services;
        }
    }
}
