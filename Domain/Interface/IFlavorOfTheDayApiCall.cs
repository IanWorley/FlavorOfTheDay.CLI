namespace Domain.Interface;

public interface IFlavorOfTheDayApiCall
{
    public Task<Dictionary<string, string>> GetFlavorOfTheDayAsync(int zipCode, int limit);
}