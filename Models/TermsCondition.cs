using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class TermsCondition
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength]
        public string Description { get; set; }
    }
}
