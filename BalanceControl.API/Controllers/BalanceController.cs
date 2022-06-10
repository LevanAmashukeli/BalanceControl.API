using BalanceControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BalanceControl.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IGetBalanceService _getBalanceService;

        public BalanceController(IGetBalanceService getBalanceService)
        {
            _getBalanceService = getBalanceService;
        }

        [HttpGet("balance")]
        public decimal Balance() => _getBalanceService.GetBalance();
    }
}