using BalanceControl.Services.Models.Balance;
using BalanceControl.Services.Models.Response;
using Balances;

namespace BalanceControl.Services.Common.Interfaces
{
        public interface IWithdrawService
        {
            ResponseViewModel<ErrorCode> Withdraw(WithdrawBalanceChangeModel model);
        }
}
