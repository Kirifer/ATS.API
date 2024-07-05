using Ats.Core.Config.Database;

namespace Ats.Core.Config
{
    public class MicroServiceConfig : IMicroServiceConfig
    {
        public DatabaseConfig? DatabaseConfig { get; set; }
    }
}
