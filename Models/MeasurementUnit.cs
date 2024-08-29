using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class MeasurementUnit
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string? Name { get; set; }
        [StringLength(5)]
        public string? ShortName { get; set; }
    }
}
