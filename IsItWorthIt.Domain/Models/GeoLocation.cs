using Newtonsoft.Json;

namespace IsItWorthIt.Domain.Models
{
    public class GeoLocation
    {
        [JsonProperty("country_short")]
        public string CountryShort { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lng")]
        public string Longitude { get; set; }

        [JsonProperty("country_long")]
        public string CountryLong { get; set; }

        [JsonProperty("region_short")]
        public string RegionShort { get; set; }

        [JsonProperty("region_long")]
        public string RegionLong { get; set; }

        [JsonProperty("city_long")]
        public string CityLong { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}