using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class ProjectsInfo
    {
        [Key]
        [DisplayName("ID")]
        public int  Id { get; set; }
         
        [StringLength(255)]
        public string Title { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        [Required]
        [StringLength(150)]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        [StringLength(100)]
        public string LocationMap { get; set; }
        [NotMapped]
        public IFormFile MapPath { get; set; }
        [NotMapped]
        public IFormFile ProjectVideo { get; set; }
        [ForeignKey("Developers")]
        public int AgentID { get; set; }
        public DevelopersorAgent Developers { get; set; }
       // public ICollection<ProjectImageGallery> ProjectImageGalleries { get; set; }
    }
}
