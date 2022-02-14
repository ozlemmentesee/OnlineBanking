using OnlineBanking.Common;
using OnlineBanking.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Response<int?> Create(CustomerDto customerDto)
        {
            var isSuccess = true;

            var message = string.Empty;

            var customer = _customerRepository.Add(customerDto);

            if (customer == null)
            {
                isSuccess = false;
                message = "Operation failed.";
            }

            return new Response<int?> { Data = customer.Value, IsSuccess = isSuccess, Message = message };
        }
    }
}
