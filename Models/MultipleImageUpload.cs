using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class MultipleImageUpload
    {
        [Key]
        public int ID { get; set; }
        public string MultiImagePath { get; set; }
        [ForeignKey("PropertyDetails")]
        public int propertyInfoId { get; set; }

        public PropertyDetails PropertyDetails { get; set; }
    }
}
