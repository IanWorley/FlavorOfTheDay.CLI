using Domain.Interface;

namespace Domain.Modal;

public class Store : IStore
{
    public StoreLocation StoreLocation { get; set; }
    public string FlavorOfTheDay { get; set; }
    public string DineInHours { get; set; }
    public string DriveThruHours { get; set; }
    public int? OnlineOrderStatus { get; set; }
    public bool? IsTemporarilyClosed { get; set; }
    public string OpenDate { get; set; }

    public ICommonStoreMethod ConvertToStoreModel()
    {
        return new SmallStore
        {
            StoreLocation = StoreLocation,
            FlavorOfTheDay = FlavorOfTheDay
        };
    }
}