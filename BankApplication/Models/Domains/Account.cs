using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace BankApplication.Models.Domains
{
    public enum AccountType
    {
        SavingsAccount,
        CurrentAccount,
        BussinessAccount,
        SalariedAccount
    }
    public class Account
    {
        [Key] 
        public Guid AccountId { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalBalance { get; set; }
        // Other account properties such as account type, status, etc.

        public Guid UserId { get; set; }  // Foreign key
        public User? User { get; set; }    // Navigation property
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
