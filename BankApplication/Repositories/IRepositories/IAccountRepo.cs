using BankApplication.Models.Domains;
using BankApplication.Models.DTOs;
using Microsoft.Identity.Client;

namespace BankApplication.Repositories.IRepositories
{
    public interface IAccountRepo
    {
        Task<List<AccountDto>> GetAllAccounts();
        Task<AccountDto> GetSingleAccount(Guid accountId);
        Task<string> AddAccountDetails(Guid id,AddAccountDto dto);
    }
}
