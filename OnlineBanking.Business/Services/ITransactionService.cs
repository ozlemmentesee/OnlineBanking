using OnlineBanking.Common;
using OnlineBanking.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Business
{
    public interface ITransactionService
    {
        Response<List<TransactionDto>> GetAll(int customerId);
        Response<List<TransactionDto>> GetAll(int customerId, TimeRequest request);
    }
}
