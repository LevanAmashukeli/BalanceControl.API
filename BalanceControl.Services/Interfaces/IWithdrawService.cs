using BalanceControl.Services.Models;
using Balances;

namespace BalanceControl.Services.Interfaces
{
        public interface IWithdrawService
        {
            ResponseViewModel<ErrorCode> Withdraw(BalanceChangeModel model);
        }
}
