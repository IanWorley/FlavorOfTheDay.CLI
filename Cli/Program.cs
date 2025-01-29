using Business;
using Culvers_cli.DI;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Culvers_cli;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var registrations = new ServiceCollection();
        registrations.AddBusinessServices();
        var registrar = new TypeRegistrar(registrations);
        var app = new CommandApp<>(registrar);
    }
}