using Domain.Interface;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Culvers_cli.Commands;

public class FlavorOfTheDayCommand : AsyncCommand<FlavorOfTheDayCommandSettings>
{
    private readonly IAnsiConsole _ansiConsole;
    private readonly IFlavorOfTheDay _flavorOfTheDay;

    public FlavorOfTheDayCommand(IFlavorOfTheDay flavorOfTheDay, IAnsiConsole ansiConsole)
    {
        _flavorOfTheDay = flavorOfTheDay;
        _ansiConsole = ansiConsole;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, FlavorOfTheDayCommandSettings settings)
    {
        var flavors = await _flavorOfTheDay.GetFlavorOfTheDayAsync(int.Parse(settings.ZipCode), settings.Limit);

        var table = new Table();
        table.Centered();
        table.AddColumn("[green]Address[/]");
        table.AddColumn(":ice_cream:Flavor of the Day:ice_cream:");

        foreach (var flavor in flavors) table.AddRow(flavor.Key, flavor.Value);

        _ansiConsole.Write(table);
        return 0;
    }

    public ValidationResult Validate(CommandContext context, CommandSettings settings)
    {
        if (settings is not FlavorOfTheDayCommandSettings flavorOfTheDayCommandSettings)
            return ValidationResult.Error("Invalid settings type");

        return flavorOfTheDayCommandSettings.Validate();
    }
}