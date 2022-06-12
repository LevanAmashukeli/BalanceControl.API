using BalanceControl.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Services.Tests.ServiceTests
{
    [TestClass]
    public class GetBalanceServiceTest
    {
        [TestMethod]
        public void Should_ThrowException_When_BalanceMoreThan10000()
        {
            var startBalance = 10000;
            GetBalanceService getBalance = new GetBalanceService();
            decimal balanceTest = getBalance.GetBalance();

            Assert.IsTrue(balanceTest > startBalance , $"The balance is more than {startBalance}");
        }

        [TestMethod]
        public void Should_ThrowException_When_BalanceLessThan0()
        {
            GetBalanceService getBalance = new GetBalanceService();
            decimal balanceTest = getBalance.GetBalance();

            Assert.IsTrue(balanceTest > 0, $"The balance is {balanceTest}, less than zero ");
        }
    }
}
