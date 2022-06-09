using BalanceControl.Services.Interfaces;
using BalanceControl.Services.Models;
using Balances;
using Microsoft.AspNetCore.Mvc;

namespace BalanceControl.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceManager _balanceManager;
        private readonly IWithdrawService _withdrawService;
        private readonly IDepositService _depositService;
        private readonly IGetBalanceService _getBalanceService;

        public BalanceController(IBalanceManager balanceManager, IWithdrawService withdrawService, IDepositService depositService, IGetBalanceService getBalanceService)
        {
            _balanceManager = balanceManager;
            _withdrawService = withdrawService;
            _depositService = depositService;
            _getBalanceService = getBalanceService;
        }

        [HttpGet("balance")]
        public decimal Balance() => _getBalanceService.GetBalance();

        [HttpPost("withdraw/{{transactionid}}/{{amount}}")]
        public ResponseViewModel<ErrorCode> Withdraw(BalanceChangeModel model) => _withdrawService.Withdraw(model);

        [HttpPost("deposit/{{transactionid}}/{{amount}}")]
        public ResponseViewModel<ErrorCode> Deposit(BalanceChangeModel model) => _depositService.Deposit(model);
    }
}