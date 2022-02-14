using OnlineBanking.Common;
using OnlineBanking.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Business
{
    public interface ICustomerService
    {
        Response<int?> Create(CustomerDto customer);
    }
}
