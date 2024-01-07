using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace USBDProperty.Models
{
    public class PropertyWithFeatures
    {

        [Key]
        public int ID { get; set; }
        [ForeignKey("PropertyDetails")]
        public int PropertyId { get; set; }
        [ForeignKey("PropertyFeatures")]
        public int  FeatureId { get; set; }

        [ValidateNever]
        public PropertyFeatures PropertyFeatures { get; set; }
        [ValidateNever]
        public PropertyDetails PropertyDetails { get; set; }
    }
}
