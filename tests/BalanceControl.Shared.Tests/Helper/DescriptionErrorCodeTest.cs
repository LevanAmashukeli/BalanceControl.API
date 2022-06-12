using System.ComponentModel;

namespace BalanceControl.Shared
{
    public enum DescriptionErrorCodeTest
    {
        [Description("Transaction is Successful. Balance is edited.")]
        Success,

        [Description("Transaction is Rejected. Balance has not changed.")]
        TransactionRejected,

        [Description("Not Enough money. The balance has not changed.")]
        NotEnoughtBalance,

        [Description("Transaction ID already exists. The balance has not changed.")]
        DuplicateTransactionId,

        [Description("Transaction is not found. The balance has not changed.")]
        TransactionNotFound,

        [Description("Transaction is already marked as Rollback. The balance has not changed.")]
        TransactionAlreadyMarkedAsRollback,

        [Description("Transaction is Rollbacked.")]
        TransactionRollbacked,

        [Description("Unknown Error! Unknown if balance has changed.")]
        UnknownError
    }
}
