using BankApplication.Data;
using BankApplication.Models.Domains;
using BankApplication.Models.DTOs;
using BankApplication.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace BankApplication.Repositories.SqlRepositories
{
    public class SqlTransactionRepo : ITransactionRepo
    {
        private readonly BankApplicationDbContext db;
        public SqlTransactionRepo(BankApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<string> AddTransaction(Guid accountNumber, AddTransactionDto dto)
        {
            var accountDetails= await db.Accounts.FirstOrDefaultAsync(x=>x.AccountId==accountNumber);

            if (accountDetails==null)
            {
                return null;
            }

            var transactionDomain = new Models.Domains.Transaction()
            {
                AccountId = accountNumber,
                TransactionType= (Models.Domains.TransactionType)dto.TransactionType,
                Amount=dto.Amount,
                Description=dto.Description,
                TransferDate = DateTime.Now,
            };
            if (dto.TransactionType.ToString() == "Debited")
            {
                accountDetails.TotalBalance-=dto.Amount;

                await db.SaveChangesAsync();
            }
            else
            {
                accountDetails.TotalBalance += dto.Amount;

                await db.SaveChangesAsync();
            }

            await db.Transactions.AddAsync(transactionDomain);
            await db.SaveChangesAsync();

            return "Done";
        }
    }
}
