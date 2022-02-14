using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class Account : BaseEntity
    {
        public int CustomerId { get; set; }
        [ConcurrencyCheck]
        public decimal Balance { get; set; }
    }
}
