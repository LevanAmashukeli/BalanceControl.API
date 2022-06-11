using BalanceControl.Shared.Handler;
using Balances;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Shared.Tests.HandlerTests
{
    [TestClass]
    public class IsNotSuccessHandlerTest
    {
        [TestMethod]
        public void IsNotSuccess_Test()
        {
            var success = ErrorCode.UnknownError;
            var isNotSuccessTest = IsNotSuccessHandler.IsNotSuccess(success);

            Assert.IsTrue(isNotSuccessTest, "The ErrorCode is Successed");
        }
    }
}
