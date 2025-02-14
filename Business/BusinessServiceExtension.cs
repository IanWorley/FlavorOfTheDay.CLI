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
        services.AddSingleton<IFlavorOfTheDayWriterFactory, FlavorOfTheDayCommandWriterFactory>();
        services.AddTransient<IFlavorOfTheDayWriter, FlavorOfTheDayCommandPlainWriter>();
        services.AddTransient<IFlavorOfTheDayWriter, FlavorOfTheDayCommandPrettyWriter>();

        return services;
    }
}