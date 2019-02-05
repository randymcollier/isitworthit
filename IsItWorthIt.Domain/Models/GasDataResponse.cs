using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IsItWorthIt.Domain.Models
{
    public class GasDataResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("stations")]
        public List<Station> Stations { get; set; }
    }
}
