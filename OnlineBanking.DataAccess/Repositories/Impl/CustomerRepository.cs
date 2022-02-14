using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class CustomerRepository : BaseRepository<Customer, CustomerDto>, ICustomerRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerRepository(DatabaseContext databaseContext, IMapper mapper, IConfiguration configuration) : base(databaseContext, mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public override int? Add(CustomerDto model)
        {
            var salt = Convert.FromBase64String(_configuration["Salt"]);

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                         password: model.Password,
                                                         salt: salt,
                                                         prf: KeyDerivationPrf.HMACSHA256,
                                                         iterationCount: 100000,
                                                         numBytesRequested: 256 / 8));
            model.Password = hashed;

            return base.Add(model);
        }
    }
}
