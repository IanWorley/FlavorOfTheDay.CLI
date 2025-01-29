using Domain.Interface;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Culvers_cli.Commands;

[Command(Description = "Finds Culver's flavor of the day Zip Code")]
public class FlavorOfTheDayCommand : ICommand
{
    private IAnsiConsole _ansiConsole;
    private readonly IFlavorOfTheDay _flavorOfTheDay;

    public FlavorOfTheDayCommand(IFlavorOfTheDay flavorOfTheDay, IAnsiConsole ansiConsole)
    {
        _flavorOfTheDay = flavorOfTheDay;
        _ansiConsole = ansiConsole;
    }

    [CommandParameter(0, Description = "You must provide a zip code")]
    public required string ZipCode { get; init; }

    [CommandOption("limit", 'l', Description = "Optional: Specify a limit of locations")]
    public int Limit { get; init; } = 1;

    public ValidationResult Validate(CommandContext context, CommandSettings settings)
    {
        throw new NotImplementedException();
    }

    public Task<int> Execute(CommandContext context, CommandSettings settings)
    {
        throw new NotImplementedException();
    }

    public async ValueTask ExecuteAsync(IConsole console)
    {
        if (Limit == 0)
        {
            throw new ArgumentException("Limit must be greater than 0");
        }

        var flavors = await _flavorOfTheDay.GetFlavorOfTheDayAsync(int.Parse(ZipCode), Limit);

        var table = new Table();
        table.Centered();
        table.AddColumn("[green]Address[/]");
        table.AddColumn(":ice_cream:Flavor of the Day:ice_cream:");

        foreach (var flavor in flavors)
        {
            table.AddRow(flavor.Key, flavor.Value);
        }

        _ansiConsole.Write(table);
    }
}