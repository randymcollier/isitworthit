using System.Net;
using Newtonsoft.Json;

namespace IsItWorthIt.Domain.Models
{
    public class Status
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("code")]
        public HttpStatusCode? Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}