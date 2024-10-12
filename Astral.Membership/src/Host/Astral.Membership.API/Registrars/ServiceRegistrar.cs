using Astral.Membership.Application.ApplicationServices;
using Astral.Membership.Core.Services;

namespace Astral.Membership.API.Registrars
{
    public class ServiceRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IMemberService, MemberService>();
        }
    }
}
