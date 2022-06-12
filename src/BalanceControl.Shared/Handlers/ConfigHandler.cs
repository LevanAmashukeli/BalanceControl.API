using Balances;
using System.Configuration;

namespace BalanceControl.Shared.Handlers
{
    public static class ConfigHandler
    {
        public static string Config(ErrorCode name)
        {
            return ConfigurationManager.AppSettings.Get(name.ToString());
        }
    }
}
