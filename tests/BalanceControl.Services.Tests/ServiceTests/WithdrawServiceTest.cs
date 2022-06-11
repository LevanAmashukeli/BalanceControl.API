using BalanceControl.Application.Common.Models.Balance;
using Balances;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Services.Tests.ServiceTests
{
    [TestClass]
    public class WithdrawServiceTest
    {
        [TestMethod]
        public void Sucess_Withdraw_Test()
        {
            var testBalanceModel = new WithdrawBalanceChangeModel
            {
                Amount = 1000,
                TransactioId = "jsdfh7733df"
            };

            WithdrawService withdraw = new WithdrawService();
            var methodTest = withdraw.Withdraw(testBalanceModel);

            var successCode = ErrorCode.Success;

            Assert.AreEqual(successCode, methodTest.ErrorCode);
        }

        [TestMethod]
        public void NoEnoughtBalance_Withdraw_Test()
        {
            var testBalanceModel = new WithdrawBalanceChangeModel
            {
                Amount = 100000,
                TransactioId = "sdfsf2213f3dad1"
            };

            WithdrawService withdraw = new WithdrawService();
            var methodTest = withdraw.Withdraw(testBalanceModel);

            var noEnoughtBalanceCode = ErrorCode.NotEnoughtBalance;

            Assert.AreEqual(noEnoughtBalanceCode, methodTest.ErrorCode);
        }

        [TestMethod]
        public void TransactionRejected_Withdraw_Test()
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
        public void DuplicateTransaction_Withdraw_Test()
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
