using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IsItWorthIt.Domain.Contracts;
using IsItWorthIt.Domain.Models;
using IsItWorthIt.Domain.Utilities;

namespace IsItWorthIt.Domain.Services
{
    public class GasStationFinder : IFindGasStations
    {
        private HttpClient _http { get; set; }

        public GasStationFinder(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<GasDataResponse> Find(GasDataRequest request)
        {
            _http.BaseAddress = new Uri("http://api.mygasfeed.com");
            var url = $"/stations/radius/{request.Latitude}/{request.Longitude}/{request.Distance}/{request.FuelType}/price/rzkel0lgcd.json";
            
            var response = await _http.GetAsync(url).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return content.FromJson<GasDataResponse>();
        }
    }
}