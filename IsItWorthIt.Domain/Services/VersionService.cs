using System.Reflection;
using IsItWorthIt.Domain.Contracts;

namespace IsItWorthIt.Domain.Services
{
    public class VersionService : ITellVersions
    {
        public string GetVersion()
        {
            return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}