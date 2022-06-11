using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Services.Tests.ServiceTests
{
    [TestClass]
    public class GetBalanceServiceTest
    {
        [TestMethod]
        public void GetBalance_StartedBalance10000_Test()
        {
            var startBalance = 10000;
            GetBalanceService getBalance = new GetBalanceService();
            decimal balanceTest = getBalance.GetBalance();

            Assert.IsTrue(balanceTest >= startBalance , $"The balance more then {startBalance}");
        }

        [TestMethod]
        public void GetBalance_MoreThen0_Test()
        {
            GetBalanceService getBalance = new GetBalanceService();
            decimal balanceTest = getBalance.GetBalance();

            Assert.IsTrue(balanceTest > 0, "The actualCount was not greater than zero");
        }
    }
}
