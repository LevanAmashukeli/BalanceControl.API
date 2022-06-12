﻿using BalanceControl.Services.Common.Interfaces;
using BalanceControl.Services.Models.Balance;
using BalanceControl.Services.Models.Response;
using BalanceControl.Shared;
using BalanceControl.Shared.Handler;
using Balances;
using System;
using System.Linq;

namespace BalanceControl.Application.Services
{
    public class DepositService : IDepositService
    {
        private readonly CasinoBalanceManager _casinoBalanceManager;
        private readonly GameBalanceManager _gameBalanceManager;

        public DepositService()
        {
            _casinoBalanceManager = new CasinoBalanceManager();
            _gameBalanceManager = new GameBalanceManager();
        }

        public ResponseViewModel<ErrorCode> Deposit(DepositBalanceChangeModel model)
        {
            if(model.IsNull())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = ErrorCode.UnknownError,
                    StatusMessage = ConfigHandler.Config(ErrorCode.UnknownError)
                };
            }
            var decrGameBalance = _gameBalanceManager.DecreaseBalance(model.Amount, model.TransactioId);

            if (decrGameBalance.IsNotSuccess())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = decrGameBalance,
                    StatusMessage = ConfigHandler.Config(decrGameBalance)
                };
            }

            var incrCasinoBalance = _casinoBalanceManager.IncreaseBalance(model.Amount, model.TransactioId);

            if (incrCasinoBalance.IsNotSuccess())
            {
                return new ResponseViewModel<ErrorCode>
                {
                    ErrorCode = incrCasinoBalance,
                    StatusMessage = ConfigHandler.Config(incrCasinoBalance)
                };
            }

            return new ResponseViewModel<ErrorCode> { ErrorCode = ErrorCode.Success, StatusMessage = ConfigHandler.Config(ErrorCode.Success) };
        }

      }
  }

