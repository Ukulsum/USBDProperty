using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Transaction Name")]
        public string TransactionTypeName { get; set; }
    }
}
