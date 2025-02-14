using Domain.Enum;
using Spectre.Console;

namespace Business.Service;

public class FlavorOfTheDayCommandPrettyWriter : IFlavorOfTheDayWriter
{
    private readonly IAnsiConsole _ansiConsole;


    public FlavorOfTheDayCommandPrettyWriter(IAnsiConsole ansiConsole)
    {
        _ansiConsole = ansiConsole;
    }


    public void DisplayFlavorOfTheDay(Dictionary<string, string> locationFlavorDictionary)
    {
        if (locationFlavorDictionary.Count == 0)
        {
            _ansiConsole.MarkupLine("[red]No flavors found for the given zip code.[/]");
            return;
        }

        if (locationFlavorDictionary.Count == 1)
        {
            _ansiConsole.MarkupLineInterpolated(
                $"[green]Flavor of the Day for {locationFlavorDictionary.First().Key}: {locationFlavorDictionary.First().Value}[/]");
            return;
        }

        var table = new Table();
        table.Centered();
        table.AddColumn("[green]Address[/]");
        table.AddColumn(":ice_cream:Flavor of the Day:ice_cream:");

        foreach (var data in locationFlavorDictionary)
            table.AddRow(data.Key, data.Value);
        _ansiConsole.Write(table);
    }

    public WriterEnum DetermineOutputColorEnum()
    {
        return WriterEnum.Pretty;
    }
}