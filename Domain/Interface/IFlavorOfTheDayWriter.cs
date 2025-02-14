using Domain.Enum;

namespace Business.Service;

public interface IFlavorOfTheDayWriter
{
    void DisplayFlavorOfTheDay(Dictionary<string, string> locationFlavorDictionary);

    public WriterEnum DetermineOutputColorEnum();
}