using BalanceControl.Shared.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BalanceControl.Shared.Tests.HandlerTests
{
    [TestClass]
    public class DescriptionHandlerTest
    {
        [TestMethod]
        public void When_Success_GetEnumDescription_IfNot_ThrowException_ToEnumDescriptionCheck()
        {
            try
            {
                var result = DescriptionErrorCodeTest.Success.GetEnumDescription();

                Assert.AreEqual(result, "Transaction is Successful. Balance is edited.");
            }
            catch (Exception)
            {
                Assert.Fail("Enum's Description not found");
            }
        }
    }
}