using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class AccountRepository : BaseRepository<Account, AccountDto>, IAccountRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public AccountRepository(DatabaseContext databaseContext, IMapper mapper) : base(databaseContext, mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public AccountDto GetByIdAndCustomer(int accountId, int customerId)
        {
            try
            {
                return _mapper.Map<AccountDto>(_databaseContext.Accounts.FirstOrDefault(x => x.Id == accountId && x.CustomerId == customerId));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override bool Update(AccountDto account)
        {
            var result = false;

            try
            {
                var entity = _databaseContext.Set<Account>().Find(account.Id);

                _databaseContext.Entry(entity).CurrentValues.SetValues(account);

                entity.ModifiedDate = DateTime.Now;

                _databaseContext.EnsureAutoHistory(() => new CustomAutoHistory()
                {
                    Kind = EntityState.Modified
                });

                SaveChanges();

                result = true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();

                _databaseContext.SaveChanges();

                throw new Exception(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
