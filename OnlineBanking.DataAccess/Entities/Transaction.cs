using OnlineBanking.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class Transaction : BaseEntity
    {
        public int AccountId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public decimal FinalBalance { get; set; }
    }
}
