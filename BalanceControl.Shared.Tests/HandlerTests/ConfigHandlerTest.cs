using BalanceControl.Shared.Handler;
using Balances;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Shared.Tests.HandlerTests
{
    [TestClass]
    public class ConfigHandlerTest
    {
        [TestMethod]
        public void Success_Config_Test()
        {
            var success = ErrorCode.Success;
            var configTest = ConfigHandler.Config(success);

            Assert.Equals(configTest, "ტრანზაქცია წარმატებულია. ბალანსი დარედაქტირდა.");
        }
    }
}