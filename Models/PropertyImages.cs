using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class PropertyImages
    {
        [Key]
        public int ID { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [ValidateNever]
        public string MultiImagePath { get; set; }
        [NotMapped]
        [ValidateNever]
        public IFormFile MultipleImage { get; set; }
        [ForeignKey("PropertyDetails")]
        public int propertyInfoId { get; set; }

        [ValidateNever]
        public PropertyDetails PropertyDetails { get; set; }
    }
}
