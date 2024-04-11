using BankApplication.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Repositories.IRepositories
{
    public interface ITransactionRepo
    {
        Task<string> AddTransaction(Guid accountNumber, AddTransactionDto dto);
    }
}
