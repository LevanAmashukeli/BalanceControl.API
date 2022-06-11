using BalanceControl.Shared.Handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Shared.Tests
{
    [TestClass]
    public static class IsNullHandlerTests
    {
        [TestMethod]
        public static void isNullTest()
        {
            object entity = null;
            var handlerTest = IsNullHandler.IsNull(entity);

            Assert.AreEqual(handlerTest, entity);
        }
    }
}
