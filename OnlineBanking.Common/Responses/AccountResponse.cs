using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Common
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
    }
}
