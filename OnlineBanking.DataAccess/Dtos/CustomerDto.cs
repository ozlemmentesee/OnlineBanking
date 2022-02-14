using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class CustomerDto : BaseDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
