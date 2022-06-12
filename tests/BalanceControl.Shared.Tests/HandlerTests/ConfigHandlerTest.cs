using Balances;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;

namespace BalanceControl.Shared.Tests.HandlerTests
{
    [TestClass]
    public class ConfigHandlerTest
    {
        [TestMethod]
        public void When_СonfigPath_NotExist_ThrowException_ToCheckConfigPath()
        {
            var success = ErrorCode.Success;

            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDfirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.Parent.FullName;
                var appSettingPath = Path.Combine(projectDfirectory, @"src\BalanceControl.API", "App.config");

                ConfigurationFileMap fileMap = new ConfigurationFileMap(appSettingPath);
                Configuration configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
                string value = configuration.AppSettings.Settings[success.ToString()].Value;

                Assert.AreEqual(value, "ტრანზაქცია წარმატებულია. ბალანსი დარედაქტირდა.");
            }
            catch (Exception)
            {
                Assert.Fail("Check 'App.config' path");
            }
        }
    }
}