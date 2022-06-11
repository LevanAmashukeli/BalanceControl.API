using BalanceControl.Application.Common.Models.Balance;
using BalanceControl.Application.Models;
using Balances;

namespace BalanceControl.Application.Interfaces
{
    public interface IDepositService
    {
        ResponseViewModel<ErrorCode> Deposit(DepositBalanceChangeModel model);
    }
}
