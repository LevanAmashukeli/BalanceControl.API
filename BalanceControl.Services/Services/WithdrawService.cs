using BalanceControl.Application.Interfaces;
using BalanceControl.Application.Models;
using BalanceControl.Shared.Handler;
using Balances;

namespace BalanceControl.Services
{
    public class WithdrawService : IWithdrawService
    {
        private readonly CasinoBalanceManager _casinoBalanceManager;
        private readonly GameBalanceManager _gameBalanceManager;

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
                    StatusMessage = ConfigHandler.Config(ErrorCode.UnknownError)
                };
            }

            var incrCasinoBalance = _casinoBalanceManager.DecreaseBalance(model.Amount, model.TransactioId);

            if (incrCasinoBalance.IsNotSuccess())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = incrCasinoBalance,
                    StatusMessage = ConfigHandler.Config(incrCasinoBalance)
                };
            }

            var decrGameBalance = _gameBalanceManager.IncreaseBalance(model.Amount, model.TransactioId);

            if (decrGameBalance.IsNotSuccess())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = decrGameBalance,
                    StatusMessage = ConfigHandler.Config(decrGameBalance)
                };
            }

            return new ResponseViewModel<ErrorCode> { ErrorCode = ErrorCode.Success, StatusMessage = ConfigHandler.Config(ErrorCode.Success) };
        }
    }
}
