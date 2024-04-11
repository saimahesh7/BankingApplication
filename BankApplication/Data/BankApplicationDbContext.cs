using BankApplication.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankApplication.Data
{
    public class BankApplicationDbContext : DbContext
    {
        public BankApplicationDbContext(DbContextOptions<BankApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Defining Relation between the Account and User Entities Explicitly
            modelBuilder.Entity<Account>()
            .HasOne(a => a.User)
            .WithMany(u => u.Accounts)
            .HasForeignKey(a => a.UserId);
            //Explicitly configure the SQL Server column type for the decimal property to avoid data loss
            modelBuilder.Entity<Account>()
             .Property(a => a.TotalBalance)
             .HasColumnType("decimal(18, 4)"); // Adjust precision and scale according to your requirements


            //Defining Relation between the Transaction and Account Entities Explicitly
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
            .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId);
            // Explicitly configure the SQL Server column type for the decimal property to avoid data loss
            modelBuilder.Entity<Transaction>()
             .Property(t => t.Amount)
             .HasColumnType("decimal(18, 4)");
        }
    }
}
