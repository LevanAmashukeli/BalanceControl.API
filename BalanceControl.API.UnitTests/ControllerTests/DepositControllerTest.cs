using BalanceControl.API.Controllers;
using BalanceControl.Application.Common.Models.Balance;
using Balances;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.API.UnitTests.ControllerTests
{
    [TestClass]
    public class DepositControllerTest
    {
        [TestMethod]
        public void asd()
        {
            var model = new DepositBalanceChangeModel()
            {
                Amount = 1000,
                TransactioId = "sdjfgjs3773sdf"
            };

            var result = DepositController.Deposit(model);

            Assert.AreEqual(result.ErrorCode, ErrorCode.Success);
        }
    }
}
