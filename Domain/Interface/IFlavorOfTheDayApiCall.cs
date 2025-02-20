namespace Domain.Interface;

public interface IFlavorOfTheDayApiCall
{
    public Task<IList<IStore>> GetFlavorOfTheDayAsync(int zipCode, int limit);
}