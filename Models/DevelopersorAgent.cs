using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USBDProperty.DTO;

namespace USBDProperty.Models
{
   public  enum Membership
    {
        Platinum=1,Gold,Silver
    }
    public class DevelopersorAgent : BaseDTO
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }
        [ValidateNever]
        [NotMapped]

        public IFormFile logofile { get; set; }
        [ValidateNever]
        [NotMapped]

     public   IFormFile bannerFile { get; set; }

        [DisplayName("About Us")]
        public string AboutUs { get; set; }
        [ValidateNever]
        public string Logo { get; set; }
        [Required]
        [ValidateNever]
        public string Banner { get; set; }
        public Membership Membership { get; set; }
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
        [DisplayName("Contact Person")]
        public string Name { get; set; }//Owner Person Name / Contact Person Name
         
        [Required]
         
        public string Address { get; set; }
        [ForeignKey("Area")]
        public int AreaID { get; set; }
        [ValidateNever]
        public Area Area { get; set; }
        public ICollection<ProjectsInfo> projectsInfos { get; set; }
    }
}
