using BalanceControl.Services.Common.Interfaces;
using BalanceControl.Services.Models.Balance;
using BalanceControl.Services.Models.Response;
using Balances;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BalanceControl.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly IDepositService _depositService;

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        [HttpPost("deposit/{{transactionid}}/{{amount}}")]
        [SwaggerOperation(Summary = "Transfer money to Casino balance", Description = "Transfer money from Game to Casino balance")]
        public ResponseViewModel<ErrorCode> Deposit(DepositBalanceChangeModel model) => _depositService.Deposit(model);
    }
}

