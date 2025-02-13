using System.Net.Http.Json;
using Domain.Interface;

namespace Business;

public class FlavorOfTheDayApiCall : IFlavorOfTheDayApiCall
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FlavorOfTheDayApiCall(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Dictionary<string, string>> GetFlavorOfTheDayAsync(int zipCode, int limit = 1)
    {
        if (limit <= 0) throw new ArgumentException("Limit must be greater than 0");

        var client = _httpClientFactory.CreateClient("FavorOfTheDayByZipLimit");
        var uri = new Uri($"https://web.culvers.com/api/locator/getLocations?location={zipCode}&limit={limit}");

        var culverStoreResponse = await client.GetFromJsonAsync<CulversStoreResponse>(uri);

        if (culverStoreResponse == null || culverStoreResponse.Data == null)
            throw new Exception("No data returned from Culvers API");


        var storeAddressFlavorDay = culverStoreResponse.Data.Geofences.Select(
            x => new KeyValuePair<string, string>(
                $"{x.Metadata.Street}, {x.Metadata.City}, {x.Metadata.State}, {x.Metadata.PostalCode}",
                x.Metadata.FlavorOfDayName)
        ).ToDictionary(x => x.Key, x => x.Value);


        return storeAddressFlavorDay;
    }
}