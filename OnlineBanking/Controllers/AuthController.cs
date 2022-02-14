using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineBanking.Business;
using OnlineBanking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Token")]
        public Response<string> Token([FromBody] UserRequest user)
        {
            var token = _authService.GetToken(user);

            bool isSuccess = !String.IsNullOrEmpty(token);

            return new Response<string> { Data = token, IsSuccess = isSuccess };
        }
    }
}