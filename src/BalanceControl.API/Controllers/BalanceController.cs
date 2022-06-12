﻿using BalanceControl.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BalanceControl.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IGetBalanceService _getBalanceService;

        public BalanceController(IGetBalanceService getBalanceService)
        {
            _getBalanceService = getBalanceService;
        }

        [HttpGet("balance")]
        [SwaggerOperation(Summary = "Check Balance", Description = "Returns Casino balance")]
        public decimal Balance() => _getBalanceService.GetBalance();
    }
}