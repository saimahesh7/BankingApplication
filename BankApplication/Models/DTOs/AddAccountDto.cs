using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.DTOs
{
    public class AddAccountDto
    {
        [Required]
        public AccountType AccountType { get; set; }
    }
}
