using BalanceControl.Shared.Handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Shared.Tests.HandlerTests
{
    [TestClass]
    public class IsNullHandlerTest
    {
        [TestMethod]
        public void When_Parameter_IsNotNull_Should_Be_Thrown_ObjectIsNotNull()
        {
            object entity = null;
            var isNullTest = IsNullHandler.IsNull(entity);

            Assert.IsTrue(isNullTest, "The object is not null");
        }
    }
}
