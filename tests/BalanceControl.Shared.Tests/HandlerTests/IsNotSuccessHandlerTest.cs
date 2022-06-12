using BalanceControl.Shared.Handler;
using Balances;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Shared.Tests.HandlerTests
{
    [TestClass]
    public class IsNotSuccessHandlerTest
    {
        [TestMethod]
        public void When_Parameter_IsNotSuccess_Should_Be_Thrown_ErrorCodeSuccessed()
        {
            var success = ErrorCode.UnknownError;
            var isNotSuccessTest = IsNotSuccessHandler.IsNotSuccess(success);

            Assert.IsTrue(isNotSuccessTest, "ErrorCode: Successed");
        }
    }
}
