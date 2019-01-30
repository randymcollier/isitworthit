

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IsItWorthIt.Domain.Contracts;
using IsItWorthIt.Domain.Models;

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
            _http.BaseAddress = new Uri("http://devapi.mygasfeed.com/");
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = await _http.GetAsync($"stations/radius/{request.Latitude}/{request.Longitude}/{request.Distance}/{request.FuelType}/price/rfej9napna.json").ConfigureAwait(false);
            return new GasDataResponse();
        }
    }
}