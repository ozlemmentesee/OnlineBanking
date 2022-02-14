using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public interface ICustomerRepository : IBaseRepository<Customer, CustomerDto>
    {
    }
}
