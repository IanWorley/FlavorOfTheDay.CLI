
using System.Net.Http.Json;
using Domain.Interface;

namespace Business;

public class FlavorOfTheDayService: IFlavorOfTheDay
{
    private readonly IHttpClientFactory _httpClientFactory;

    
    public FlavorOfTheDayService(IHttpClientFactory httpClientFactory)
    {
        this._httpClientFactory = httpClientFactory;
    }

    public async Task<Dictionary<string, string>> GetFlavorOfTheDayAsync(int zipCode, int limit = 1)
    {

        var client = _httpClientFactory.CreateClient("FavorOfTheDayByZipLimit1");
        var uri = new Uri($"https://web.culvers.com/api/locator/getLocations?location={zipCode}&limit={limit}");

        var culverStoreResponse = await client.GetFromJsonAsync<CulversStoreResponse>(uri);

        
        var storeAddressFlavorDay =  culverStoreResponse.Data.Geofences.Select( 
            x => new KeyValuePair<string, string>($"{x.Metadata.Street}, {x.Metadata.City}, {x.Metadata.State}, {x.Metadata.PostalCode}" , x.Metadata.FlavorOfDayName)
        ).ToDictionary(x => x.Key, x => x.Value);
             

        return storeAddressFlavorDay;

    }

}