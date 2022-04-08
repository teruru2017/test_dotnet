namespace octa_dotnet.Installers
{
    public interface IInstallers
    {
         void Installservices (IServiceCollection services, IConfiguration configuration);

    }
}