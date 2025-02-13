using Business.Service;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class BusinessServiceExtension
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddTransient<IFlavorOfTheDayApiCall, FlavorOfTheDayApiCall>();
        services.AddSingleton<IFlavorOfTheDayCommandOutputFactory, FlavorOfTheDayCommandOutputFactory>();
        services.AddTransient<IFlavorOfTheDayCommandOutput, FlavorOfTheDayCommandPlainOutput>();
        services.AddTransient<IFlavorOfTheDayCommandOutput, FlavorOfTheDayCommandPrettyOutput>();

        return services;
    }
}