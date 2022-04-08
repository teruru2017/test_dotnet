using System.Reflection;

namespace octa_dotnet.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallserviceInAssembly(this IServiceCollection services, IConfiguration configuration){
          var installers =  typeof(Program).Assembly.ExportedTypes.Where(x =>
            typeof(IInstallers).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .Select (Activator.CreateInstance).Cast<IInstallers>().ToList();

        installers.ForEach(installer => installer.Installservices(services,configuration));

                
        }

    }
}