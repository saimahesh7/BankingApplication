using BankApplication.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.DTOs
{
    public enum AccountType
    {
        SavingsAccount,
        CurrentAccount,
        BussinessAccount,
        SalariedAccount
    }
    public class AccountDto
    {
        [Required]
        public Guid AccountId { get; set; }
        public AccountType AccountType { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalBalance { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Username { get; set; } = "";
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        [Required, DataType(DataType.Text)]
        public string FullName { get; set; } = "";
        [Required, DataType(DataType.MultilineText)]
        public string Address { get; set; } = "";
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = "";
        // Other account properties such as account type, status, etc.

        public List<TransactionDto> TransactionDtos { get; set; }
    }
}
