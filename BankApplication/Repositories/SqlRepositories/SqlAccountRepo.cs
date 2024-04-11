using BankApplication.Data;
using BankApplication.Models.Domains;
using BankApplication.Models.DTOs;
using BankApplication.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace BankApplication.Repositories.SqlRepositories
{
    public class SqlAccountRepo : IAccountRepo
    {
        private readonly BankApplicationDbContext dbContext;

        public SqlAccountRepo(BankApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> AddAccountDetails(Guid id,AddAccountDto dto)
        {
            var accountDomain=await dbContext.Accounts.Where(i=>i.UserId==id)
                .FirstOrDefaultAsync(x => x.AccountType== (Models.Domains.AccountType)dto.AccountType);
            if (accountDomain==null)
            {
                var account=new Account()
                {
                    UserId= id,
                    AccountType = (Models.Domains.AccountType)dto.AccountType,
                };
                await dbContext.Accounts.AddAsync(account);
                await dbContext.SaveChangesAsync();
                return "done";
            }
            return "Account with the provided Id and AccountType is already existed";
            
        }

        public async Task<List<AccountDto>> GetAllAccounts()
        {
            var studentList=await dbContext.Accounts.Include(u=>u.User).ToListAsync();

            var studentListDto = new List<AccountDto>();
            foreach (var student in studentList)
            {
                var accountdto= new AccountDto
                {
                    AccountId=student.AccountId,
                    FullName = student.User?.FirstName + student.User?.LastName,
                    Username = student.User?.Username,
                    Email = student.User?.Email,
                    PhoneNumber = student.User?.PhoneNumber,
                    Address = student.User?.Address,
                    AccountType = (Models.DTOs.AccountType)student.AccountType,
                    TotalBalance = student.TotalBalance,
                };
                studentListDto.Add(accountdto);
            }
            return studentListDto;
        }

        public async Task<AccountDto> GetSingleAccount(Guid accountId)
        {
            var accountDetails=await dbContext.Accounts.Include(u=>u.User).Include(t=>t.Transactions).FirstOrDefaultAsync(x=>x.AccountId==accountId);
            if (accountDetails == null)
            {
                return null;
            }

            var sortedTransaction=accountDetails.Transactions.OrderByDescending(x=>x.TransferDate
            ).ToList();

            var transactionDtos=new List<TransactionDto>();
            for(int i=0;i<=5;i++)
            {
                var dto = new TransactionDto
                {
                    TransactionId = sortedTransaction[i].TransactionId,
                    TransactionType = (Models.DTOs.TransactionType)sortedTransaction[i].TransactionType,
                    Description = sortedTransaction[i].Description,
                    TransferDate = sortedTransaction[i].TransferDate,
                    Amount = sortedTransaction[i].Amount,
                };

                transactionDtos.Add(dto);
            }

            var accountDto = new AccountDto()
            {
                AccountId = accountId,
                AccountType= (Models.DTOs.AccountType)accountDetails.AccountType,
                TotalBalance = accountDetails.TotalBalance,
                Username=accountDetails.User?.Username,
                FullName=accountDetails.User?.FirstName+" "+accountDetails.User?.LastName,
                Email=accountDetails.User?.Email,
                Address=accountDetails.User?.Address,
                PhoneNumber=accountDetails.User?.PhoneNumber,
                TransactionDtos=transactionDtos,
            };

            return accountDto;
        }
    }
}
