using Ats.Core.Config.Authentication;
using Ats.Core.Config.Database;

namespace Ats.Core.Config
{
    public interface IMicroServiceConfig
    {
        DatabaseConfig? DatabaseConfig { get; set; }
        JwtConfig? JwtConfig { get; set; }
    }
}
