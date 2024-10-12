
using Astral.Membership.Application.ApplicationCommands.MemberCommands;
using Astral.Membership.Application.ApplicationCommands.TokenCommands;
using Astral.Membership.Application.ApplicationCommands.UserCommands;
using Astral.Membership.Application.ApplicationQueries.MemberQueries;

namespace Astral.Membership.API.Registrars
{
    public class MediatrRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            //Commands
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(UpdatePasswordCommandHandler).Assembly));
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateTokenCommandHandler).Assembly));
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateMemberCommandHandler).Assembly));

            //Queries
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetMemberQueryHandler).Assembly));
        }
    }
}
