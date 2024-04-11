using BankApplication.Models.DTOs;
using BankApplication.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepo accountRepo;

        public AccountsController(IAccountRepo accountRepo)
        {
            this.accountRepo = accountRepo;
        }

        [HttpGet]
        public async Task<IActionResult> AllAccounts()
        {
            var accountsList=await accountRepo.GetAllAccounts();
            return Ok(accountsList);
        }

        [HttpGet]
        [Route("{accountId:guid}")]
        public async Task<IActionResult> AccountDetails(Guid accountId)
        {
            var accountDetails=await accountRepo.GetSingleAccount(accountId);
            if(accountDetails == null)
            {
                return NotFound("The Account you are looking for is not found");
            }
            return Ok(accountDetails);
        }

        //lets do Post Endpoint
        [HttpPost]
        [Route("{userId:guid}")]
        public async Task<IActionResult> AddAccount(Guid userId,[FromBody]AddAccountDto dto)
        {
            var account=await accountRepo.AddAccountDetails(userId, dto);
            if (account=="done")
            {
                return Ok("Account has Created"); 
            }
            return BadRequest(account);
        }
    }
}
