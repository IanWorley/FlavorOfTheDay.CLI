using Domain.Enum;

namespace Business.Service;

public interface IFlavorOfTheDayCommandOutput
{
    void DisplayFlavorOfTheDay(Dictionary<string, string> locationFlavorDictionary);

    public OutputColorEnum DetermineOutputColorEnum();
}