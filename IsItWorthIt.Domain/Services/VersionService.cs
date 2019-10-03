using System.Reflection;
using IsItWorthIt.Domain.Contracts;
using IsItWorthIt.Domain.Models;

namespace IsItWorthIt.Domain.Services
{
    public class VersionService : ITellVersions
    {
        public Versioning GetVersion()
        {
            return new Versioning { Version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion };
        }
    }
}