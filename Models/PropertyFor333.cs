using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class PropertyFor333
    {
        [Key]
        [DisplayName("ID")]
        public int PropertyForId { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Property For")]
        public string PropeFor { get; set; }
    }
}
