using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class City
    {
        [Key]
        [DisplayName("ID")]
        public int CityId { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("City")]
        public string CityName { get; set; }
        [ForeignKey("Division")]
        public int DivisionId { get; set; }

        [ValidateNever]
        public Division Division { get; set; }
    }
}
