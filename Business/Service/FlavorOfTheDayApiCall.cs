using System.Net.Http.Json;
using Domain.Interface;
using Domain.Modal;

namespace Business;

public class FlavorOfTheDayApiCall : IFlavorOfTheDayApiCall
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FlavorOfTheDayApiCall(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    public async Task<IList<IStore>> GetFlavorOfTheDayAsync(int zipCode, int limit = 1)
    {
        if (limit <= 0) throw new ArgumentException("Limit must be greater than 0");

        var client = _httpClientFactory.CreateClient("FavorOfTheDayByZipLimit");
        var uri = new Uri($"https://web.culvers.com/api/locator/getLocations?location={zipCode}&limit={limit}");

        var culverStoreResponse = await client.GetFromJsonAsync<CulversStoreResponse>(uri);

        if (culverStoreResponse == null || culverStoreResponse.Data == null)
            throw new Exception("No data returned from Culvers API");

        if (culverStoreResponse.IsSuccessful == false)
            throw new Exception("Culvers API could not find any stores for the given zip code");

        IList<IStore> storeAddressFlavorDay = culverStoreResponse.Data.Geofences.Select(x => (IStore)new Store
        {
            StoreLocation = new StoreLocation
            {
                Street = x.Metadata.Street,
                City = x.Metadata.City,
                State = x.Metadata.State,
                ZipCode = x.Metadata.PostalCode
            },
            FlavorOfTheDay = x.Metadata.FlavorOfDayName,
            DineInHours = x.Metadata.DineInHours,
            DriveThruHours = x.Metadata.DriveThruHours,
            OnlineOrderStatus = x.Metadata.OnlineOrderStatus
        }).ToList();

        return storeAddressFlavorDay;
    }
}