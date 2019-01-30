using System.Collections.Generic;
using System.Net;
using IsItWorthIt.Domain.Models;

namespace IsItWorthIt.Tests.Utilities
{
    public static class GasDataHelper
    {
        public static GasDataResponse OK_EmptyStations()
        {
            return new GasDataResponse
            {
                Status = new Status
                {
                    Error = "NO",
                    Code = HttpStatusCode.OK,
                    Description = "none",
                    Message = "Request ok"
                },
                Stations = new List<Station>()
            };
        }
    }
}