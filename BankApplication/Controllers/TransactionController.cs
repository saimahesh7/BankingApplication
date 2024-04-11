using BankApplication.Models.DTOs;
using BankApplication.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepo transactionRepo;

        public TransactionController(ITransactionRepo transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }


        [HttpPost]
        [Route("{accountNumber:guid}")]
        public async Task<IActionResult> AddTransaction(Guid accountNumber,[FromBody] AddTransactionDto dto)
        {
            var transactionResult=await transactionRepo.AddTransaction(accountNumber, dto);
            if (transactionResult=="Done")
            {
                return Ok("Transaction Successfull");
            }
            return BadRequest("Something went wrong , Please Check once");
        }
    }
}
