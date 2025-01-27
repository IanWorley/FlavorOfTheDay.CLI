using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Domain.Interface;
using Spectre.Console;

namespace Culvers_cli.Commands;
[Command(Description = "Finds Culver's flavor of the day Zip Code")]

public class FlavorOfTheDayCommand: ICommand
{
    private IFlavorOfTheDay _flavorOfTheDay;
    private IAnsiConsole _ansiConsole;
    
    [CommandParameter(0, Description = "You must provide a zip code")]
    public required string ZipCode { get; init; }

    [CommandOption("limit", 'l', Description = "Optional: Specify a limit of locations")]
    public int Limit { get; init; } = 1;

    public FlavorOfTheDayCommand(IFlavorOfTheDay flavorOfTheDay, IAnsiConsole ansiConsole)
    {
        this._flavorOfTheDay = flavorOfTheDay;
        this._ansiConsole = ansiConsole;
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