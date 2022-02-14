using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineBanking.DataAccess
{
    public class CustomAutoHistory : AutoHistory
    {
        public CustomAutoHistory()
        {
            Created = DateTime.Now;
        }
        public EntityState Kind { get; set; }
    }
}
