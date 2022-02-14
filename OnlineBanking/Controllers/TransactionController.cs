using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Business;
using OnlineBanking.Common;
using OnlineBanking.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.API.Controllers
{
    public class TransactionController : BaseController
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customerId = int.Parse(this.User.Claims.First(i => i.Type == "Id").Value);

            var response = _transactionService.GetAll(customerId);

            return new JsonResult(response);
        }

        [HttpGet("ByDate")]
        public IActionResult GetByDate(DateTime startDate, DateTime endDate)
        {
            var customerId = int.Parse(this.User.Claims.First(i => i.Type == "Id").Value);

            var response = _transactionService.GetAll(customerId, new TimeRequest { StartDate = startDate, EndDate = endDate });

            return new JsonResult(response);
        }
    }
}
