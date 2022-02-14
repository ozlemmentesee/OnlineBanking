using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public interface IAccountRepository : IBaseRepository<Account, AccountDto>
    {
        AccountDto GetByIdAndCustomer(int accountId, int customerId);
    }
}
