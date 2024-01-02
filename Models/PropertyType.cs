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
    }

    public class PropertyTypeVm
    {
        [Key]
        public int PropertyTypeId { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Property Type")]
        public string PropertyTypeName { get; set; }
        public int? ParentPropertyTypeId { get; set; } = 0;
        [NotMapped]
        public string ParentPropertyType { get; set; }
    }
}
