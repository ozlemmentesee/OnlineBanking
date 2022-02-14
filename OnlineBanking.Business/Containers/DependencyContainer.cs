using Microsoft.Extensions.DependencyInjection;
using OnlineBanking.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class DependencyContainer
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
