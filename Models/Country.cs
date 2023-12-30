using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace USBDProperty.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Country")]
        public string CountryName { get; set; }
    }
}
