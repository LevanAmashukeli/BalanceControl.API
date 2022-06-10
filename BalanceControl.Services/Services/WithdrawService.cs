using BalanceControl.Application.Interfaces;
using BalanceControl.Application.Models;
using BalanceControl.Shared.Handler;
using Balances;

namespace BalanceControl.Services
{
    public class WithdrawService : IWithdrawService
    {
        private readonly IBalanceManager _casinoBalanceManager;
        private readonly IBalanceManager _gameBalanceManager;

        public WithdrawService()
        {
            _casinoBalanceManager = new CasinoBalanceManager();
            _gameBalanceManager = new GameBalanceManager();
        }

        public ResponseViewModel<ErrorCode> Withdraw(BalanceChangeModel model)
        {
            if (model.IsNull())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = ErrorCode.UnknownError,
                    StatusMessage = "Amount or/and TransactioID can't be empty!"
                };
            }

            var incrCasinoBalance = _casinoBalanceManager.DecreaseBalance(model.Amount, model.TransactioId);

            if (incrCasinoBalance.IsNotSuccess())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = incrCasinoBalance
                };
            }

            var decrGameBalance = _gameBalanceManager.IncreaseBalance(model.Amount, model.TransactioId);

            if (decrGameBalance.IsNotSuccess())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = decrGameBalance
                };
            }

            return new ResponseViewModel<ErrorCode> { ErrorCode = ErrorCode.Success };
        }
    }
}
