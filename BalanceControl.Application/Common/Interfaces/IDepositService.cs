using BalanceControl.Application.Models;
using Balances;

namespace BalanceControl.Application.Interfaces
{
    public interface IDepositService
    {
        ResponseViewModel<ErrorCode> Deposit(BalanceChangeModel model);
    }
}
