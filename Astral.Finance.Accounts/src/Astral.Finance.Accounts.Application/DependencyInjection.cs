
using Astral.Finance.Accounts.Application.Abstractions.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Astral.Finance.Accounts.Application
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


            return services;
        }
    }
}
