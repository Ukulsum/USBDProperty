using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using USBDProperty.DTO;

namespace USBDProperty.Models
{
    public class Notice : BaseDTO
    {
        [Key]
        public int NoticeID { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public string Images { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

    }
}
