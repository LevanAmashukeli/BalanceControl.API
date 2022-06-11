using BalanceControl.API.Controllers;
using BalanceControl.Application.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.API.UnitTests
{
    [TestClass]
    public class BalanceControllerTest
    {
         BalanceController _controller;
         IGetBalanceService _service;

        public BalanceControllerTest()
        {
            _controller = new BalanceController(_service);
        }

        [TestMethod]
        public void GetBalance_HealthCheck_Test()
        {
            var result = _controller.Balance();

            Assert.IsTrue(result > 0);
        }
    }
}
