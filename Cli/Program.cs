using Business;
using Culvers_cli.Commands;
using Culvers_cli.DI;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Culvers_cli;

public static class Program
{
    public static void Main(string[] args)
    {
        var registrations = new ServiceCollection();
        registrations.AddBusinessServices();
        var registrar = new TypeRegistrar(registrations);
        var app = new CommandApp<FlavorOfTheDayCommand>(registrar);
        app.Run(args);
    }
}