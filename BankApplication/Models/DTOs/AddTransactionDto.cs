using BankApplication.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models.DTOs
{
   
    public class AddTransactionDto
    {
        
        public TransactionType TransactionType { get; set; }
        /*[DataType(DataType.DateTime)]
        public DateTime TransferDate { get; set; }*/
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = "";
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}
