using Domain.Enum;
using Spectre.Console;

namespace Business.Service;

public class FlavorOfTheDayCommandPlainWriter : IFlavorOfTheDayWriter
{
    private readonly IAnsiConsole _ansiConsole;


    public FlavorOfTheDayCommandPlainWriter(IAnsiConsole ansiConsole)
    {
        _ansiConsole = ansiConsole;
    }

    public void DisplayFlavorOfTheDay(Dictionary<string, string> locationFlavorDictionary)
    {
        if (locationFlavorDictionary.Count == 0)
        {
            _ansiConsole.WriteLine("No flavors found for the given zip code.");
            return;
        }

        if (locationFlavorDictionary.Count == 1)
        {
            _ansiConsole.WriteLine(
                $"Flavor of the Day for {locationFlavorDictionary.First().Key}: {locationFlavorDictionary.First().Value}");
            return;
        }

        foreach (var data in locationFlavorDictionary)
            _ansiConsole.WriteLine($"{data.Key}: {data.Value}");
    }

    public WriterEnum DetermineOutputColorEnum()
    {
        return WriterEnum.Plain;
    }
}