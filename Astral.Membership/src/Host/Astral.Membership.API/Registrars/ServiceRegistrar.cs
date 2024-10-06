using Astral.Membership.Core.Services;
using Astral.Membership.Infrastructure.Services;

namespace Astral.Membership.API.Registrars
{
    public class ServiceRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
        }
    }
}
