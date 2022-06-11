using BalanceControl.Services.Common.Interfaces;
using Balances;

namespace BalanceControl.Application.Services
{
    public class GetBalanceService : IGetBalanceService
    {
        private readonly CasinoBalanceManager _casinoBalanceManager;

        public GetBalanceService()
        {
            _casinoBalanceManager = new CasinoBalanceManager();
        }

        public decimal GetBalance()
        {
            return _casinoBalanceManager.GetBalance();
        }
    }
}


