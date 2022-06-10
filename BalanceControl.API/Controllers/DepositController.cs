using BalanceControl.Application.Interfaces;
using BalanceControl.Application.Models;
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
        [SwaggerOperation(Summary = "თანხის გადატანა კაზინოში", Description = "აკეთებს თანხის გადარიცხვას კაზინოს ბალანსიდან თამაშის ბალანსზე")]
        public ResponseViewModel<ErrorCode> Deposit(BalanceChangeModel model) => _depositService.Deposit(model);
    }
}

