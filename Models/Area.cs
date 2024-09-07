using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class Area
    {
        [Key]
        [DisplayName("ID")]
        public int AreaId { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Area")]
        public string AreaName { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }


        [ValidateNever]
        public City City { get; set; }
    }
}
