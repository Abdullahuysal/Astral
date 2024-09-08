
using Astral.Membership.Application.ApplicationQueries.UserQueries;

namespace Astral.Membership.API.Registrars
{
    public class AutoMapperRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program),typeof(GetUserQuery));
        }
    }
}
