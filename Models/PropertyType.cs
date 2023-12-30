using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class PropertyType
    {
        [Key]
        public int PropertyTypeId { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Property Type")]
        public string PropertyTypeName { get; set; }
    }
}
