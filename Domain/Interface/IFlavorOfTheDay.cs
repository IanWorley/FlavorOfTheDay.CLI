namespace Domain.Interface;

public interface IFlavorOfTheDay
{
    public Task<Dictionary<string, string>> GetFlavorOfTheDayAsync(int zipCode, int limit);
}