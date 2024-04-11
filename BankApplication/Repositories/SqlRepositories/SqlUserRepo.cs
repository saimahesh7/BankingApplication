using BankApplication.Data;
using BankApplication.Models.Domains;
using BankApplication.Models.DTOs;
using BankApplication.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Repositories.SqlRepositories
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly BankApplicationDbContext dbContext;

        public SqlUserRepo(BankApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddUserDeatails(AddUserDto dto)
        {
            //convert dto data into domain data
            var userDomain = new User()
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Accounts = new List<Account>()
                {
                    new Account
                    {
                        AccountType=(Models.Domains.AccountType)dto.AccountType,
                    }
                }
            };

            await this.dbContext.Users.AddAsync(userDomain);
            await dbContext.SaveChangesAsync();
        }

        public async Task<UserDto?> UserDeatails(Guid userId)
        {
            var userDetails =await dbContext.Users.Include(a=>a.Accounts).FirstOrDefaultAsync(x => x.UserId == userId);
            if (userDetails != null)
            {
                List<AccountsDto> accountDetails = new List<AccountsDto>();
                foreach (var account in userDetails.Accounts)
                {
                    var accountdto=new AccountsDto()
                    {
                        AccountId = account.AccountId,
                        AccountType = (Models.DTOs.AccountType)account.AccountType,
                        TotalBalance = account.TotalBalance,
                        
                    };
                    accountDetails.Add(accountdto);
                }

                var userDto = new UserDto()
                {
                    Username = userDetails.Username,
                    FullName = userDetails.FirstName + " " + userDetails.LastName,
                    PhoneNumber = userDetails.PhoneNumber,
                    Accounts = accountDetails,
                };

                return userDto;
            }
            return null;
        }
    }
}
