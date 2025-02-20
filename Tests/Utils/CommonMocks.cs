using System.Net;
using System.Text.Json;
using Domain.Interface;
using Domain.Modal;

namespace Tests.Utils;

public static class CommonMocks
{
    public static IList<IStore> MakeFakeStoresList()
    {
        return new List<IStore>
        {
            new Store
            {
                StoreLocation = new StoreLocation
                {
                    Street = "123 Main St",
                    City = "Springfield",
                    State = "IL",
                    ZipCode = "62701"
                },
                FlavorOfTheDay = "Vanilla",
                DineInHours = "10:00 AM - 10:00 PM",
                DriveThruHours = "10:00 AM - 11:00 PM",
                OnlineOrderStatus = 1,
                IsTemporarilyClosed = false
            },
            new Store
            {
                StoreLocation = new StoreLocation
                {
                    Street = "456 Elm St",
                    City = "Springfield",
                    State = "IL",
                    ZipCode = "62702"
                },
                FlavorOfTheDay = "Chocolate",
                DineInHours = "10:00 AM - 10:00 PM",
                DriveThruHours = "10:00 AM - 11:00 PM",
                OnlineOrderStatus = 1,
                IsTemporarilyClosed = true
            }
        };
    }


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
                        new()
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