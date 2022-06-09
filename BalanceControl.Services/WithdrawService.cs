using BalanceControl.Services.Interfaces;
using BalanceControl.Services.Models;
using Balances;

namespace BalanceControl.Services
{
    public class WithdrawService : IWithdrawService
    {
        private readonly CasinoBalanceManager _casinoBalanceManager;
        private readonly GameBalanceManager _gameBalanceManager;

        public WithdrawService(CasinoBalanceManager casinoBalanceManager, GameBalanceManager gameBalanceManager)
        {
            _casinoBalanceManager = casinoBalanceManager;
            _gameBalanceManager = gameBalanceManager;
        }

        public ResponseViewModel<ErrorCode> Withdraw(BalanceChangeModel model)
        {
            if (model == null)
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = ErrorCode.UnknownError,
                    StatusMessage = "Amount or/and TransactioID can't be empty!"
                };
            }

            var incrCasinoBalance = _casinoBalanceManager.IncreaseBalance(model.Amount, model.TransactioId);

            if (incrCasinoBalance != ErrorCode.Success)
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = incrCasinoBalance
                };
            }

            var decrGameBalance = _gameBalanceManager.DecreaseBalance(model.Amount, model.TransactioId);

            if (decrGameBalance != ErrorCode.Success)
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
