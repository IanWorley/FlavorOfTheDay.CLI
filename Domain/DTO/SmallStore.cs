using Domain.Interface;
using Domain.Modal;

namespace Domain;

public class SmallStore : ICommonStoreMethod
{
    public SmallStore(IStore store)
    {
        StoreLocation = store.StoreLocation;
        FlavorOfTheDay = store.FlavorOfTheDay;
    }

    public SmallStore()
    {
    }


    public StoreLocation StoreLocation { get; set; }
    public string FlavorOfTheDay { get; set; }


    public ICommonStoreMethod ConvertToStoreModel()
    {
        return new SmallStore
        {
            StoreLocation = StoreLocation,
            FlavorOfTheDay = FlavorOfTheDay
        };
    }
}