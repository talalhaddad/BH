using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHBackendAPI.Models
{
    public class TransactionsDBModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
