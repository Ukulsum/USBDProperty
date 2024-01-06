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
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength]
        public string Description { get; set; }
    }
}
