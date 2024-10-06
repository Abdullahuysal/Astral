
using Astral.Membership.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Astral.Membership.API.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var sqlConnection = builder.Configuration.GetConnectionString("SqlConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(sqlConnection));
        }
    }
}
