using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class PrivacyPolicy
    {
        [Key]
        [DisplayName("ID")]
        public int PpId { get; set; }
        [Required]
        [StringLength(40)]
        public string Title { get; set; }
        [Required]
        [MaxLength]
        public string Description { get; set; }
    }
}
