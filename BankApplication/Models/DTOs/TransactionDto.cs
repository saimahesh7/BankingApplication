using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.DTOs
{
    public enum TransactionType
    {
        Credited,
        Debited
    }
    public class TransactionDto
    {
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        [DataType(DataType.Date)]
        public DateTime TransferDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}
