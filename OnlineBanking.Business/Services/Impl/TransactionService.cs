using OnlineBanking.Common;
using OnlineBanking.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Business
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public Response<List<TransactionDto>> GetAll(int customerId)
        {
            var transactionList = _transactionRepository.GetAll(customerId);

            return new Response<List<TransactionDto>> { Data = transactionList, IsSuccess = true };
        }

        public Response<List<TransactionDto>> GetAll(int customerId, TimeRequest request)
        {
            var transactionList = _transactionRepository.GetAll(customerId, request);

            return new Response<List<TransactionDto>> { Data = transactionList, IsSuccess = true };

        }
    }
}
