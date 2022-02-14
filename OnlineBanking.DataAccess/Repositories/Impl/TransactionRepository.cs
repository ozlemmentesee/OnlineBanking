using AutoMapper;
using OnlineBanking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class TransactionRepository : BaseRepository<Transaction, TransactionDto>, ITransactionRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public TransactionRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public List<TransactionDto> GetAll(int customerId)
        {
            var result = new List<TransactionDto>();

            List<Transaction> list;

            try
            {
                list = _databaseContext.Transactions
                    .Join(_databaseContext.Accounts,
                       x => x.AccountId,
                       y => y.Id,
                       (x, y) => new { Transaction = x, Account = y })
                    .Where(z => z.Account.CustomerId == customerId)
                    .Select(x => new Transaction
                    {
                        Id = x.Transaction.Id,
                        AccountId = x.Transaction.AccountId,
                        Type = x.Transaction.Type,
                        Amount = x.Transaction.Amount,
                        FinalBalance = x.Transaction.FinalBalance
                    }).ToList();

                result = _mapper.Map<List<TransactionDto>>(list);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<TransactionDto> GetAll(int customerId, TimeRequest request)
        {
            var result = new List<TransactionDto>();

            List<Transaction> list;

            try
            {
                list = _databaseContext.Transactions
                    .Join(_databaseContext.Accounts,
                       x => x.AccountId,
                       y => y.Id,
                       (x, y) => new { Transaction = x, Account = y })
                    .Where(z => z.Account.CustomerId == customerId && z.Transaction.CreatedDate >= request.StartDate && z.Transaction.CreatedDate <= request.EndDate)
                    .Select(x => new Transaction
                    {
                        Id = x.Transaction.Id,
                        AccountId = x.Transaction.AccountId,
                        Type = x.Transaction.Type,
                        Amount = x.Transaction.Amount,
                        FinalBalance = x.Transaction.FinalBalance
                    }).ToList();

                result = _mapper.Map<List<TransactionDto>>(list);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
