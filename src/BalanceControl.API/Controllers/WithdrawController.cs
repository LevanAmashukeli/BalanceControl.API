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
    public class WithdrawController : ControllerBase
    {
        private readonly IWithdrawService _withdrawService;

        public WithdrawController(IWithdrawService withdrawService)
        {
            _withdrawService = withdrawService;
        }

        [HttpPost("withdraw/{{transactionid}}/{{amount}}")]
        [SwaggerOperation(Summary = "თანხის გადატანა თამაშში", Description = "აკეთებს თანხის გადმორიცხვას თამაშის ბალანსიდან კაზინოს ბალანსზე")]
        public ResponseViewModel<ErrorCode> Withdraw(WithdrawBalanceChangeModel model) => _withdrawService.Withdraw(model);
    }
}
