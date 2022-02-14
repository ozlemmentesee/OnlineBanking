using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.API
{
    public class UserRequest
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
