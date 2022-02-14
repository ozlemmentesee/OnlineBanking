using Microsoft.AspNetCore.Authorization;
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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(CustomerDto customer)
        {
            var response = _customerService.Create(customer);

            return new JsonResult(response);
        }
    }
}
