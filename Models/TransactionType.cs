using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class TransactionType
    {
        [Key]
        [DisplayName("ID")]
        public int TransactionTypeId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Transaction Name")]
        public string TransactionTypeName { get; set; }
    }
}
