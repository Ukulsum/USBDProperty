using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USBDProperty.DTO;

namespace USBDProperty.Models
{
    public class Notice : BaseDTO
    {
        [Key]
        [DisplayName("ID")]
        public int NoticeID { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        public bool IsFeatured { get; set; }
        [MaxLength]
        public string Description { get; set; }
        [ValidateNever]
        public string Path { get; set; }
        [NotMapped]
        [ValidateNever]
        [DisplayName("Photos")]
        public IFormFile Images { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

    }
}
