using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Configuration;

public static class DBConfigurationExtension
{
    public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services); //excepciones si no hay servicio 

        services.AddDbContext<EFCoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("EFCoreDataBase"),
             sqlServerOption =>
             {
                 sqlServerOption.EnableRetryOnFailure(); //si se desconecta volver a intentar 
             })
        );
    }
}
