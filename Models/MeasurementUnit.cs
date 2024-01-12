using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class MeasurementUnit
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
    }
}
