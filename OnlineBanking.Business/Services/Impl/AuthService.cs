using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineBanking.API;
using OnlineBanking.DataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OnlineBanking.Business
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;
        public AuthService(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _configuration = configuration;
        }

        public string GetToken(UserRequest request)
        {
            var result = string.Empty;

            var customer = _customerRepository.GetById(request.CustomerId);

            if (customer != null)
            {
                var salt = Convert.FromBase64String(_configuration["Salt"]);

                var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                           password: request.Password,
                                                           salt: salt,
                                                           prf: KeyDerivationPrf.HMACSHA256,
                                                           iterationCount: 100000,
                                                           numBytesRequested: 256 / 8));


                if (String.Equals(customer.Password, hashedPassword))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Salt"].ToString());
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[] { new Claim("Id", customer.Id.ToString()) }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    result = tokenHandler.WriteToken(token);
                }
            }

            return result;
        }
    }
}

