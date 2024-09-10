
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Repositories;
using Astral.Membership.Infrastructure.Repositories;

namespace Astral.Membership.API.Registrars
{
    public class RepositoryRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
