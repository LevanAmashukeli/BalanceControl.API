using BalanceControl.Application.Services;
using BalanceControl.Services.Models.Balance;
using Balances;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Services.Tests.ServiceTests
{
    [TestClass]
    public class WithdrawServiceTest
    {
        [TestMethod]
        public void When_Success_Expect_WithdrawMoney()
        {
            var testBalanceModel = new WithdrawBalanceChangeModel
            {
                Amount = 1000,
                TransactioId = "jsdfhs7733df"
            };

            WithdrawService withdraw = new WithdrawService();
            var methodTest = withdraw.Withdraw(testBalanceModel);

            var successCode = ErrorCode.Success;

            Assert.IsTrue(successCode == methodTest.ErrorCode, $"Error Code: {methodTest.ErrorCode}");
        }

        [TestMethod]
        public void When_NotEnoughtBalance_Expect_WithdrawMoneyToFail()
        {
            var testBalanceModel = new WithdrawBalanceChangeModel
            {
                Amount = 100000,
                TransactioId = "sdfsf2213f3dad1"
            };

            WithdrawService withdraw = new WithdrawService();
            var methodTest = withdraw.Withdraw(testBalanceModel);

            var notEnoughtBalanceCode = ErrorCode.NotEnoughtBalance;

            Assert.AreEqual(notEnoughtBalanceCode, methodTest.ErrorCode);
        }

        [TestMethod]
        public void When_TransactionRejected_Expect_WithdrawMoneyToFail()
        {
            var testBalanceModel = new WithdrawBalanceChangeModel
            {
                Amount = -1000,
                TransactioId = "11fdsadf31"
            };

            WithdrawService withdraw = new WithdrawService();
            var methodTest = withdraw.Withdraw(testBalanceModel);

            var rejectedBalanceCode = ErrorCode.TransactionRejected;

            Assert.AreEqual(rejectedBalanceCode, methodTest.ErrorCode);
        }

        [TestMethod]
        public void When_DuplicateTransaction_Expect_WithdrawMoneyToFail()
        {
            var testBalanceModel = new WithdrawBalanceChangeModel
            {
                Amount = 1000,
                TransactioId = "test3311test"
            };

            WithdrawService withdraw = new WithdrawService();
            withdraw.Withdraw(testBalanceModel);
            var duplicateTest = withdraw.Withdraw(testBalanceModel);

            var duplicateTransactionCode = ErrorCode.DuplicateTransactionId;

            Assert.AreEqual(duplicateTransactionCode, duplicateTest.ErrorCode);
        }
    }
}
