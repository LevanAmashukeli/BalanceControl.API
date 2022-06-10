using BalanceControl.Application.Interfaces;
using BalanceControl.Application.Models;
using Balances;
using Microsoft.AspNetCore.Mvc;

namespace BalanceControl.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly IDepositService _depositService;

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        [HttpPost("deposit/{{transactionid}}/{{amount}}")]
        public ResponseViewModel<ErrorCode> Deposit(BalanceChangeModel model) => _depositService.Deposit(model);
    }
}

