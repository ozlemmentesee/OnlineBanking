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
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Create()
        {
            var customerId = int.Parse(this.User.Claims.First(i => i.Type == "Id").Value);

            var response = _accountService.Create(new AccountDto { CustomerId = customerId });

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _accountService.Get(id);

            return new JsonResult(response);
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit(FinanceRequest financeRequest)
        {
            var customerId = int.Parse(this.User.Claims.First(i => i.Type == "Id").Value);

            var response = _accountService.Deposit(customerId, financeRequest);

            return new JsonResult(response);
        }

        [HttpPost("Withdraw")]
        public IActionResult Withdraw(FinanceRequest financeRequest)
        {
            var customerId = int.Parse(this.User.Claims.First(i => i.Type == "Id").Value);

            var response = _accountService.Withdraw(customerId, financeRequest);

            return new JsonResult(response);
        }
    }
}
