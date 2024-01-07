 using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class PropertyWithFeatures
    {
        [Key]
        [DisplayName("ID")]
        public int PropertyFeatureId { get; set; }
        [Required]
        [MaxLength]
        [DisplayName("Property Feature")]
        public string PropertyFeatureName { get; set; }
        [ForeignKey("PropertyDetails")]
        public int PropertyInfoId { get; set; }


        [ValidateNever]
        public PropertyDetails PropertyDetails { get; set; }
    }
}
