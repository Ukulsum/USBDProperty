using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class SocialIcon
    {
        [Key]
        [DisplayName("ID")]
        public int IconId { get; set; }
        [Required]
        public string Icon { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
    }
}
