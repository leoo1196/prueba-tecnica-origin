using Core.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;
public static class RepositoriesRegisterExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IOperationRepository, OperationRepository>();

        return services;
    }
}
