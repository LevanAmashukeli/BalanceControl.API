using BalanceControl.Services.Interfaces;
using BalanceControl.Services.Models;
using Balances;

namespace BalanceControl.Services
{
    public class DepositService : IDepositService
    {
        private readonly CasinoBalanceManager _casinoBalanceManager;
        private readonly GameBalanceManager _gameBalanceManager;

        public DepositService(CasinoBalanceManager casinoBalanceManager, GameBalanceManager gameBalanceManager)
        {
            _casinoBalanceManager = casinoBalanceManager;
            _gameBalanceManager = gameBalanceManager;
        }

        public ResponseViewModel<ErrorCode> Deposit(BalanceChangeModel model)
        {
            if(model == null)
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = ErrorCode.UnknownError,
                    StatusMessage = "Amount or/and TransactioID can't be empty!"
                };
            }

            var decrGameBalance = _gameBalanceManager.IncreaseBalance(model.Amount, model.TransactioId);

            if (decrGameBalance != ErrorCode.Success)
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = decrGameBalance
                };
            }

            var incrCasinoBalance = _casinoBalanceManager.DecreaseBalance(model.Amount, model.TransactioId);

            if (incrCasinoBalance != ErrorCode.Success)
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = incrCasinoBalance
                };
            }

            return new ResponseViewModel<ErrorCode> { ErrorCode = ErrorCode.Success };
        }

      }
  }

