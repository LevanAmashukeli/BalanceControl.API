using BalanceControl.Application.Models;
using Balances;

namespace BalanceControl.Application.Interfaces
{
        public interface IWithdrawService
        {
            ResponseViewModel<ErrorCode> Withdraw(BalanceChangeModel model);
        }
}
