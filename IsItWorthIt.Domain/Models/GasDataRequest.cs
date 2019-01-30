using Newtonsoft.Json;

namespace IsItWorthIt.Domain.Models
{
    public class GasDataRequest
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lng")]
        public string Longitude { get; set; }

        [JsonProperty("distance")]
        public string Distance { get; set; }

        [JsonProperty("type")]
        public string FuelType { get; set; }
    }
}