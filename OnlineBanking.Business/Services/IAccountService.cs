using OnlineBanking.Common;
using OnlineBanking.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Business
{
    public interface IAccountService
    {
        Response<int?> Create(AccountDto account);
        Response<AccountDto> Get(int accountId);
        Response<bool> Deposit(int customerId, FinanceRequest financeRequest);
        Response<bool> Withdraw(int customerId, FinanceRequest financeRequest);
    }
}
