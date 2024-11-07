
using Serilog;

namespace Astral.Membership.API.Registrars
{
    public class LoggerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {

            builder.Host.UseSerilog((context, config) =>
            {
                config.MinimumLevel.Information()
                      .WriteTo.Console()
                      .WriteTo.File("log.txt");
            });

        }
    }
}
