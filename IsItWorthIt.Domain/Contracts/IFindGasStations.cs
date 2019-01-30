using System.Threading.Tasks;
using IsItWorthIt.Domain.Models;

namespace IsItWorthIt.Domain.Contracts
{
    public interface IFindGasStations
    {
        Task<GasDataResponse> Find(GasDataRequest request);
    }
}