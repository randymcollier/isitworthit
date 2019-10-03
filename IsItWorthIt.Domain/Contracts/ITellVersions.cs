using IsItWorthIt.Domain.Models;

namespace IsItWorthIt.Domain.Contracts
{
    public interface ITellVersions
    {
        Versioning GetVersion();
    }
}