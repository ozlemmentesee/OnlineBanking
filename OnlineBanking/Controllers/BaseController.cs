using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BaseController : Controller
    {
    }
}

