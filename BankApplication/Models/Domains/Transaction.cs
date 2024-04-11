using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.Domains
{
    public enum TransactionType
    {
        Credited,
        Debited
    }
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        [DataType(DataType.Date)]
        public DateTime TransferDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        

        public Guid AccountId { get; set; }  // Foreign key
        public Account? Account { get; set; } // Navigation property

    }
}
