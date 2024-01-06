using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class FloorPlan
    {
        [Key]
        [DisplayName("ID")]
        public int FloorPlanId { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Floor Plan")]
        public string FloorPlanName { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey("PropertyDetails")]
        public int PropertyInfoID { get; set; }



        public PropertyDetails PropertyDetails { get; set; }
    }
}
