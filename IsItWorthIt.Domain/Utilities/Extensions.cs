using IsItWorthIt.Domain.Models;
using Newtonsoft.Json;

namespace IsItWorthIt.Domain.Utilities
{
    public static class Extensions
    {
        public static GasDataResponse FromJson(this string json) => JsonConvert.DeserializeObject<GasDataResponse>(json, Converter.Settings);
        public static string ToJson(this GasDataResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}