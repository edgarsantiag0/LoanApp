using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.RequestFeatures;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApp.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoansController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly ICustomerLoanBusiness _business;

        public CustomerLoansController(ICustomerLoanBusiness business,
         ILoggerManager logger)
        {
            _business = business;
            _logger = logger;

        }

        [HttpGet(Name = "GetCustomerLoans")]
        public async Task<IActionResult> GetItems([FromQuery] CustomerLoanParameters parameters) 
        {
            var data = await _business.GetPagedListDto(parameters, trackChanges: false);

            return Ok(data);
        }


    }
}
