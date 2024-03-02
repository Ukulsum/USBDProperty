 using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class PropertyFeatures
    {
        [Key]
        [DisplayName("ID")]
        public int PropertyFeatureId { get; set; }
        [Required]
      
        [DisplayName("Feature")]
        [StringLength(150)]
        public string PropertyFeatureName { get; set; }
        [DisplayName("Feature Description ")]
        public string  FeatureDescription{ get; set; }
        //[ForeignKey("PropertyDetails")]
        //public int PropertyInfoId { get; set; }


        //[ValidateNever]
        //public PropertyDetails PropertyDetails { get; set; }

    }
}
