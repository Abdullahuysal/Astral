namespace Astral.Membership.API.Registrars
{
    public interface IWebApplicationBuilderRegistrar: IRegistrar
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}
