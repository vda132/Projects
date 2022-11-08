using ASP.Net.MediatR.DAL;

namespace ASP.Net.MediatR.Extensions;

public static class InitData
{
    public static WebApplication InitDB(this WebApplication host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var databaseInitializer = services.GetRequiredService<IDatabaseInitializer>();
                databaseInitializer.SeedAsync().Wait();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogInformation(ex.Message);
            }
        }
        return host;
    }
}
