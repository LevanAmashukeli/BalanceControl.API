﻿using BalanceControl.Application.Interfaces;
using Balances;

namespace BalanceControl.Services
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


