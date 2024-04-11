using BankApplication.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.DTOs
{
    public class UserDto
    {
        
        [Required, DataType(DataType.Text)]
        public string Username { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string FullName { get; set; } = "";
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = "";
        
        public List<AccountsDto>? Accounts { get; set; }
    }
    
}
