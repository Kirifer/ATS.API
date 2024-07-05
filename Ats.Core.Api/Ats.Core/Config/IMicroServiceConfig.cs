using Ats.Core.Config.Database;

namespace Ats.Core.Config
{
    public interface IMicroServiceConfig
    {
        DatabaseConfig? DatabaseConfig { get; set; }
    }
}
