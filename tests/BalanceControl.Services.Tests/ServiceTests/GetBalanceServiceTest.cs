using BalanceControl.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Services.Tests.ServiceTests
{
    [TestClass]
    public class GetBalanceServiceTest
    {
        [TestMethod]
        public void GetBalance_EqualsOrMoreThan10000_Test()
        {
            var startBalance = 10000;
            GetBalanceService getBalance = new GetBalanceService();
            decimal balanceTest = getBalance.GetBalance();

            Assert.IsTrue(balanceTest >= startBalance , $"The balance is more than {startBalance}");
        }

        [TestMethod]
        public void GetBalance_EqualsOrMoreThan0_Test()
        {
            GetBalanceService getBalance = new GetBalanceService();
            decimal balanceTest = getBalance.GetBalance();

            Assert.IsTrue(balanceTest >= 0, "The balance is less than 0");
        }
    }
}
