using BalanceControl.Application.Interfaces;
using BalanceControl.Application.Models;
using BalanceControl.Shared.Handler;
using Balances;

namespace BalanceControl.Services
{
    public class DepositService : IDepositService
    {
        private readonly IBalanceManager _casinoBalanceManager;
        private readonly IBalanceManager _gameBalanceManager;

        public DepositService()
        {
            _casinoBalanceManager = new CasinoBalanceManager();
            _gameBalanceManager = new GameBalanceManager();
        }

        public ResponseViewModel<ErrorCode> Deposit(BalanceChangeModel model)
        {
            if(model.IsNull())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = ErrorCode.UnknownError,
                    StatusMessage = "გაურკვეველი შეცდომა, უცნობია ბალანსი შეიცვალა თუ არა."
                };
            }

            var decrGameBalance = _gameBalanceManager.DecreaseBalance(model.Amount, model.TransactioId);

            if (decrGameBalance.IsNotSuccess())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = decrGameBalance
                };
            }

            var incrCasinoBalance = _casinoBalanceManager.IncreaseBalance(model.Amount, model.TransactioId);

            if (incrCasinoBalance.IsNotSuccess())
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

