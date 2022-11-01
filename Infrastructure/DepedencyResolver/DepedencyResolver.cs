using Application.InterfacesRepos;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DepedencyResolver;

public class DepedencyResolver
{
    public static void RegisterInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IManagerRepository, ManagerRepository>();
        services.AddScoped<IBoxRepository, BoxRepository>();
    }
}