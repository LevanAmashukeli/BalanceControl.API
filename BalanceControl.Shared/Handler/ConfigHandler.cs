﻿using Balances;
using System.Configuration;

namespace BalanceControl.Shared.Handler
{
    public static class ConfigHandler
    {
        public static string Config(ErrorCode name)
        {
            return ConfigurationManager.AppSettings.Get(name.ToString());
        }
    }
}
