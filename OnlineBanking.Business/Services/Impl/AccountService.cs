using OnlineBanking.Common;
using OnlineBanking.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Business
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly DatabaseContext _databaseContext;
        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository, DatabaseContext databaseContext)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _databaseContext = databaseContext;
        }

        public Response<int?> Create(AccountDto accountDto)
        {
            var isSuccess = true;

            var message = string.Empty;

            var account = _accountRepository.Add(accountDto);

            if (account == null)
            {
                isSuccess = false;
                message = "Operation failed.";
            }

            return new Response<int?> { Data = account.Value, IsSuccess = isSuccess, Message = message };
        }

        public Response<AccountDto> Get(int accountId)
        {
            var isSuccess = true;

            var message = string.Empty;

            var account = _accountRepository.GetById(accountId);

            if (account == null)
            {
                isSuccess = false;
                message = "Account not found.";
            }

            return new Response<AccountDto> { Data = account, IsSuccess = isSuccess, Message = message };
        }

        public Response<bool> Deposit(int customerId, FinanceRequest financeRequest)
        {
            var isSuccess = false;

            var message = string.Empty;

            using var transaction = _databaseContext.Database.BeginTransaction();

            try
            {
                var account = _accountRepository.GetByIdAndCustomer(financeRequest.AccountId, customerId);

                if (account != null)
                {
                    _accountRepository.Update(new AccountDto { Id = account.Id, CustomerId = account.CustomerId, Balance = account.Balance + financeRequest.Amount });

                    _transactionRepository.Add(new TransactionDto { AccountId = account.Id.Value, Type = TransactionType.Deposit, Amount = financeRequest.Amount });

                    transaction.Commit();

                    isSuccess = true;
                }
                else
                {
                    message = "Account not found.";
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                message = "Operation failed.";
            }

            return new Response<bool> { Data = true, IsSuccess = isSuccess, Message = message };
        }

        public Response<bool> Withdraw(int customerId, FinanceRequest financeRequest)
        {
            var isSuccess = false;

            var message = string.Empty;

            using var transaction = _databaseContext.Database.BeginTransaction();

            try
            {
                var account = _accountRepository.GetByIdAndCustomer(financeRequest.AccountId, customerId);

                if (account != null)
                {
                    if (account.Balance > financeRequest.Amount)
                    {
                        _accountRepository.Update(new AccountDto { Id = account.Id, CustomerId = account.CustomerId, Balance = account.Balance - financeRequest.Amount });

                        _transactionRepository.Add(new TransactionDto { AccountId = account.Id.Value, Type = TransactionType.Withdraw, Amount = financeRequest.Amount });

                        transaction.Commit();

                        isSuccess = true;
                    }
                    else
                    {
                        message = "Insufficient balance.";
                    }
                }
                else
                {
                    message = "Account not found.";
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                message = "Operation failed.";
            }

            return new Response<bool> { Data = true, IsSuccess = isSuccess, Message = message };
        }
    }
}


