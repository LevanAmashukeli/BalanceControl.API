using Balances;
using Microsoft.AspNetCore.Mvc;

namespace BalanceControl.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceManager _balanceManager;

        public BalanceController(IBalanceManager balanceManager)
        {
            _balanceManager = balanceManager;
        }

        [HttpPost("balance")]
        public decimal GetBalance() => _balanceManager.GetBalance();

        [HttpPost("withdraw/{{transactionid}}/{{amount}}")]
        public ErrorCode DecreaseBalance(decimal amount, string transactioId) => _balanceManager.DecreaseBalance(amount, transactioId);

        [HttpPost("deposit/{{transactionid}}/{{amount}}")]
        public ErrorCode IncreaseBalance(decimal amount, string transactioId) => _balanceManager.IncreaseBalance(amount, transactioId);
    }
}