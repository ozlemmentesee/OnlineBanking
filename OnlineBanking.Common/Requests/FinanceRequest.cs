using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBanking.Common
{
    public class FinanceRequest
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
