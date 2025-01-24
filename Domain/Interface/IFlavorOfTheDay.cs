namespace Domain.Interface;

public interface IFlavorOfTheDay
{
    
    public Task<Dictionary<string, string>> GetFlavorOfTheDay(int zipCode, int limit);
}