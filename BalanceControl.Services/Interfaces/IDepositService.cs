using BalanceControl.Services.Models;
using Balances;

namespace BalanceControl.Services.Interfaces
{
    public interface IDepositService
    {
        ResponseViewModel<ErrorCode> Deposit(BalanceChangeModel model);
    }
}
