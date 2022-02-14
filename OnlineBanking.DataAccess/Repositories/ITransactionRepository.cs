using OnlineBanking.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public interface ITransactionRepository : IBaseRepository<Transaction, TransactionDto>
    {
        List<TransactionDto> GetAll(int customerId);
        List<TransactionDto> GetAll(int customerId, TimeRequest request);
    }
}
