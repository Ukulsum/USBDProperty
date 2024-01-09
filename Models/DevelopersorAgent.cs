using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using USBDProperty.DTO;

namespace USBDProperty.Models
{
    public class DevelopersorAgent : BaseDTO
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public string Banner { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Contact Number")]
        public string ContactNo { get; set; }
        [StringLength(150)]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }//Owner Person Name / Contact Person Name
        [Required]
        [StringLength(150)]
        [DisplayName("Posted By")]
        public string PostedBy { get; set; }

        public ICollection<ProjectsInfo> projectsInfos { get; set; }
    }
}
