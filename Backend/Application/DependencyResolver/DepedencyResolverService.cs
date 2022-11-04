using Application.InterfacesServices;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public static class DepedencyResolverService
{
    public static void RegisterApplicationLayer(IServiceCollection services)
    {
        services.AddScoped<IBoxService, BoxService>();
    }
}