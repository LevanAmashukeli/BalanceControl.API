using BalanceControl.Services.Interfaces;
using Balances;

namespace BalanceControl.Services
{
    public class GetBalanceService : IGetBalanceService
    {
        private readonly CasinoBalanceManager _casinoBalanceManager;

        public GetBalanceService(CasinoBalanceManager casinoBalanceManager)
        {
            _casinoBalanceManager = casinoBalanceManager;
        }

        public decimal GetBalance()
        {
            return _casinoBalanceManager.GetBalance();
        }

    }
}


