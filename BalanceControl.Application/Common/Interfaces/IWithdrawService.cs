using BalanceControl.Application.Common.Models.Balance;
using BalanceControl.Application.Models;
using Balances;

namespace BalanceControl.Application.Interfaces
{
        public interface IWithdrawService
        {
            ResponseViewModel<ErrorCode> Withdraw(WithdrawBalanceChangeModel model);
        }
}
