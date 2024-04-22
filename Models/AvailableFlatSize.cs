using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class AvailableFlatSize
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("PropertyDetails")]
        public int PropertyId { get; set; }
        //public int PropertyId { get; set; }

        [DisplayName ("Flat Size")]
        public string AvailableFSize { get; set; }
        [ForeignKey("MeasurementUnits")]
        public int UnitID { get; set; }

        [ValidateNever]
        public PropertyDetails PropertyDetails { get; set; }
        [ValidateNever]
        public MeasurementUnit MeasurementUnits { get; set; }
    }
}
