using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class AutoMapperContainer : Profile
    {
        public AutoMapperContainer()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}

