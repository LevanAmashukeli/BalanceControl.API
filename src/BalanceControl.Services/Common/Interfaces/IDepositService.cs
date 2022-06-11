using BalanceControl.Services.Models.Balance;
using BalanceControl.Services.Models.Response;
using Balances;

namespace BalanceControl.Services.Common.Interfaces
{
    public interface IDepositService
    {
        ResponseViewModel<ErrorCode> Deposit(DepositBalanceChangeModel model);
    }
}
