using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class BusinessServiceExtension
{
    
public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddTransient<IFlavorOfTheDay, FlavorOfTheDay>();
        return services;
    }
}