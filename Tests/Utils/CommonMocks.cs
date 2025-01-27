using System.Net;
using System.Text.Json;

namespace Tests.Utils;

public static class CommonMocks
{

    public static HttpResponseMessage WorkingMockedJsonResponse()
    {

        return new HttpResponseMessage
        {

            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonSerializer.Serialize(new CulversStoreResponse
            {
                Data = new Data
                {
                    Geofences = new List<Geofence>
                    {
                        new Geofence
                        {
                            Metadata = new Metadata
                            {
                                Street = "123 Main St",
                                City = "Springfield",
                                State = "IL",
                                PostalCode = "62701",
                                FlavorOfDayName = "Vanilla"
                            }
                        }
                    }
                }
            }))
        };
    }
}
    