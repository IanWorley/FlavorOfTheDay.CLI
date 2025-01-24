using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Domain.Interface;

namespace Command;
[Command(Description = "Finds Culver's flavor of the day Zip Code")]

public class ZipCodeCommand: ICommand
{
    private IFlavorOfTheDay _flavorOfTheDay;
    
    [CommandParameter(0, Description = "You must provide a zip code")]
    public required string ZipCode { get; init; }

    [CommandOption("limit", 'l', Description = "Optional: Specify a limit of locations")]
    public int Limit { get; init; } = 1;

    public ZipCodeCommand(IFlavorOfTheDay flavorOfTheDay)
    {
        this._flavorOfTheDay = flavorOfTheDay;
    }

    public async ValueTask ExecuteAsync(IConsole console)
    {
        
        

       await _flavorOfTheDay.GetFlavorOfTheDay(int.Parse(ZipCode), Limit).ContinueWith(
            task =>
            {
                foreach (var item in task.Result)
                {
                    console.Output.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        );
    }

}