using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class PropertyFeatures
    {
        [Key]
        public int PropertyFeatureId { get; set; }
        [Required]
        [MaxLength]
        [DisplayName("Property Feature")]
        public string PropertyFeatureName { get; set; }
    }
}
