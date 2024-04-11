using BankApplication.Models.DTOs;
using BankApplication.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;

        public UserController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        [HttpGet]
        [Route("{userId:guid}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var userDetails = await userRepo.UserDeatails(userId);
            if (userDetails == null)
            {
                return NotFound();
            }
            return Ok(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDto dto)
        {
            try
            {
                await userRepo.AddUserDeatails(dto);
                return Ok("User and Account for the user has been created");
            }
            catch ( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
