
using Astral.Membership.Application.ApplicationCommands.UserCommands;

namespace Astral.Membership.API.Registrars
{
    public class MediatrRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(LoginUserCommandHandler).Assembly));

        }
    }
}
