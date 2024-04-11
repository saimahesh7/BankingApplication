using BankApplication.Models.DTOs;

namespace BankApplication.Repositories.IRepositories
{
    public interface IUserRepo
    {
        Task AddUserDeatails(AddUserDto dto);
        Task<UserDto> UserDeatails(Guid userId);
    }
}
