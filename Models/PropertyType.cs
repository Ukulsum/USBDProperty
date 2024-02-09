using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? ParentPropertyTypeId { get; set; } = 0;
        [ValidateNever]
        public bool IsLand { get; set; }
    }

    public class PropertyTypeVm
    {
        [Key]
        [DisplayName("ID")]
        public int PropertyTypeId { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Property Type")]
        public string PropertyTypeName { get; set; }
        public int? ParentPropertyTypeId { get; set; } = 0;
        [NotMapped]
        public string ParentPropertyType { get; set; }
        [ValidateNever]
        public bool IsLand { get; set; }
    }
}
