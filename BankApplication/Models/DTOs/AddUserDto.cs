using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.DTOs
{
    public class AddUserDto
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Username { get; set; } = "";
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string FirstName { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string LastName { get; set; } = "";
        [Required, DataType(DataType.MultilineText)]
        public string Address { get; set; } = "";
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = "";
        [Required]
        public AccountType AccountType { get; set; }
    }
}
