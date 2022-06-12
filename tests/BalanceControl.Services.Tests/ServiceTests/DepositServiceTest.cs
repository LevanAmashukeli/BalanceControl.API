using BalanceControl.Application.Services;
using BalanceControl.Services.Models.Balance;
using Balances;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalanceControl.Services.Tests.ServiceTests
{
    [TestClass]
    public class DepositServiceTest
    {
        [TestMethod]
        public void When_Success_Expect_DepositMoney()
        {
            var testBalanceModel = new DepositBalanceChangeModel
            {
                Amount = 1000,
                TransactioId = "jsdfh7733df"
            };

            DepositService deposit = new DepositService();
            var methodTest = deposit.Deposit(testBalanceModel);

            var successCode = ErrorCode.Success;

            Assert.AreEqual(successCode, methodTest.ErrorCode);
        }

        [TestMethod]
        public void When_NotEnoughtBalance_Expect_DepositMoneyToFail()
        {
            var testBalanceModel = new DepositBalanceChangeModel
            {
                Amount = 100000,
                TransactioId = "sdfsf2213f3dad1"
            };

            DepositService deposit = new DepositService();
            var methodTest = deposit.Deposit(testBalanceModel);

            var notEnoughtBalanceCode = ErrorCode.NotEnoughtBalance;

            Assert.AreEqual(notEnoughtBalanceCode, methodTest.ErrorCode);
        }

        [TestMethod]
        public void When_TransactionRejected_Expect_DepositMoneyToFail()
        {
            var testBalanceModel = new DepositBalanceChangeModel
            {
                Amount = -1000,
                TransactioId = "11fdsadf31"
            };

            DepositService deposit = new DepositService();
            var methodTest = deposit.Deposit(testBalanceModel);

            var rejectedBalanceCode = ErrorCode.TransactionRejected;

            Assert.AreEqual(rejectedBalanceCode, methodTest.ErrorCode);
        }

        [TestMethod]
        public void When_DuplicateTransaction_Expect_DepositMoneyToFail()
        {
            var testBalanceModel = new DepositBalanceChangeModel
            {
                Amount = 1000,
                TransactioId = "test3311test"
            };

            DepositService deposit = new DepositService();
            deposit.Deposit(testBalanceModel);
            var duplicateTest = deposit.Deposit(testBalanceModel);

            var duplicateTransactionCode = ErrorCode.DuplicateTransactionId;

            Assert.AreEqual(duplicateTransactionCode, duplicateTest.ErrorCode);
        }
    }
}
