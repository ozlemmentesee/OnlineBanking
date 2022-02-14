using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class AccountDto : BaseDto
    {
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}
