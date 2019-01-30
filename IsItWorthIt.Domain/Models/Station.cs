using Newtonsoft.Json;

namespace IsItWorthIt.Domain.Models
{
    public class Station
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("zip")]
        public string Zip { get; set; }
        
        [JsonProperty("reg_price")]
        public string RegularPrice { get; set; }
        
        [JsonProperty("mid_price")]
        public string MidGradePrice { get; set; }
        
        [JsonProperty("pre_price")]
        public string PremiumPrice { get; set; }
        
        [JsonProperty("diesel_price")]
        public string DieselPrice { get; set; }
        
        [JsonProperty("reg_date")]
        public string RegularDate { get; set; }
        
        [JsonProperty("mid_date")]
        public string MidGradeDate { get; set; }
        
        [JsonProperty("pre_date")]
        public string PremiumDate { get; set; }
        
        [JsonProperty("diesel_date")]
        public string DieselDate { get; set; }
        
        [JsonProperty("address")]
        public string Address { get; set; }
        
        [JsonProperty("diesel")]
        public string Diesel { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        
        [JsonProperty("lng")]
        public string Longitude { get; set; }
        
        [JsonProperty("station")]
        public string StationType { get; set; }
        
        [JsonProperty("region")]
        public string Region { get; set; }
        
        [JsonProperty("city")]
        public string City { get; set; }
        
        [JsonProperty("distance")]
        public string Distance { get; set; }
    }
}