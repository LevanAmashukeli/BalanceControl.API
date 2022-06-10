using BalanceControl.Application.Interfaces;
using BalanceControl.Application.Models;
using Balances;
using Microsoft.AspNetCore.Mvc;

namespace BalanceControl.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly IWithdrawService _withdrawService;

        public WithdrawController(IWithdrawService withdrawService)
        {
            _withdrawService = withdrawService;
        }

        [HttpPost("withdraw/{{transactionid}}/{{amount}}")]
        public ResponseViewModel<ErrorCode> Withdraw(BalanceChangeModel model) => _withdrawService.Withdraw(model);
    }
}
