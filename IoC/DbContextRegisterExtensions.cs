using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IoC;
public static class DbContextRegisterExtensions
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("OriginTestDb")));
    }

    public static IHost InitDatabase(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        dbContext.Database.EnsureCreated();

        return app;
    }
}
