using Ats.Core.Config.Authentication;
using Ats.Core.Config.Database;

namespace Ats.Core.Config
{
    public class MicroServiceConfig : IMicroServiceConfig
    {
        public DatabaseConfig? DatabaseConfig { get; set; }
        public JwtConfig? JwtConfig { get; set; }
    }
}
