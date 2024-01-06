using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class MultipleImageUpload
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string MultiImagePath { get; set; }
        [NotMapped]
        public IFormFile MultipleImage { get; set; }
        [ForeignKey("PropertyDetails")]
        public int propertyInfoId { get; set; }

        [ValidateNever]
        public PropertyDetails PropertyDetails { get; set; }
    }
}
