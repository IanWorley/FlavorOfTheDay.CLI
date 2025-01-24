// CulversStoreResponse myDeserializedClass = JsonSerializer.Deserialize<CulversStoreResponse>(myJsonResponse);

using System.Text.Json.Serialization;

public class Address
    {
        [JsonPropertyName("addressLabel")]
        public string AddressLabel { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("countryFlag")]
        public string CountryFlag { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        [JsonPropertyName("distance")]
        public double? Distance { get; set; }

        [JsonPropertyName("formattedAddress")]
        public string FormattedAddress { get; set; }

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("stateCode")]
        public string StateCode { get; set; }

        [JsonPropertyName("layer")]
        public string Layer { get; set; }

        [JsonPropertyName("timeZone")]
        public TimeZone TimeZone { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("geofences")]
        public List<Geofence> Geofences { get; set; }

        [JsonPropertyName("totalResults")]
        public int? TotalResults { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }

    public class Geofence
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("live")]
        public bool? Live { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("geometryCenter")]
        public GeometryCenter GeometryCenter { get; set; }

        [JsonPropertyName("geometryRadius")]
        public int? GeometryRadius { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<List<List<double?>>> Coordinates { get; set; }
    }

    public class GeometryCenter
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double?> Coordinates { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("code")]
        public int? Code { get; set; }
    }

    public class Metadata
    {
        [JsonPropertyName("dineInHours")]
        public string DineInHours { get; set; }

        [JsonPropertyName("driveThruHours")]
        public string DriveThruHours { get; set; }

        [JsonPropertyName("onlineOrderStatus")]
        public int? OnlineOrderStatus { get; set; }

        [JsonPropertyName("flavorOfDayName")]
        public string FlavorOfDayName { get; set; }

        [JsonPropertyName("flavorOfTheDayDescription")]
        public string FlavorOfTheDayDescription { get; set; }

        [JsonPropertyName("flavorOfDaySlug")]
        public string FlavorOfDaySlug { get; set; }

        [JsonPropertyName("openDate")]
        public string OpenDate { get; set; }

        [JsonPropertyName("isTemporarilyClosed")]
        public bool? IsTemporarilyClosed { get; set; }

        [JsonPropertyName("utcOffset")]
        public int? UtcOffset { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("oloId")]
        public string OloId { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("jobsearchurl")]
        public string Jobsearchurl { get; set; }

        [JsonPropertyName("handoffOptions")]
        public string HandoffOptions { get; set; }
    }

    public class CulversStoreResponse
    {
        [JsonPropertyName("isSuccessful")]
        public bool? IsSuccessful { get; set; }

        [JsonPropertyName("message")]
        public object Message { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class TimeZone
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("currentTime")]
        public DateTime? CurrentTime { get; set; }

        [JsonPropertyName("utcOffset")]
        public int? UtcOffset { get; set; }

        [JsonPropertyName("dstOffset")]
        public int? DstOffset { get; set; }
    }

