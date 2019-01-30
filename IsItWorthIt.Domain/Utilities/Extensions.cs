using IsItWorthIt.Domain.Models;
using Newtonsoft.Json;

namespace IsItWorthIt.Domain.Utilities
{
    public static class Extensions
    {
        public static T FromJson<T>(this string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);
        public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}