using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.DTOs
{
    public class AccountsDto
    {
        public Guid AccountId { get; set; }
        public AccountType AccountType { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalBalance { get; set; }
    }
}
