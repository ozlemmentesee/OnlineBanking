using Microsoft.EntityFrameworkCore;
using System;

namespace OnlineBanking.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CustomAutoHistory> AutoHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);

            modelBuilder.Entity<Account>()
                 .Property(p => p.Balance)
                 .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Transaction>()
                 .Property(p => p.Amount)
                 .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Transaction>()
                 .Property(p => p.FinalBalance)
                 .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Account>()
                 .Property(a => a.Balance).IsConcurrencyToken();

            modelBuilder.EnableAutoHistory<CustomAutoHistory>(null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
