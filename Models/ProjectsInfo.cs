using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace USBDProperty.Models
{
    public class ProjectsInfo
    {
        [Key]
        [DisplayName("ID")]
        public int  Id { get; set; }
         
        [StringLength(40)]
        public string Title { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        [StringLength(100)]
        [ValidateNever]
        public string? LocationMap { get; set; }
        [NotMapped]
        public IFormFile MapPath { get; set; }
        [ValidateNever]
        public string? ProjectVideo { get; set; }
        [NotMapped]
        [ValidateNever]
        public IFormFile? ProjectVideoPath { get; set; }
        [ForeignKey("Developers")]
        public int AgentID { get; set; }
        public DevelopersorAgent Developers { get; set; }
        [ForeignKey("Area")]
        public int AreaID { get; set; }
        [ValidateNever]
        public Area Area { get; set; }
       // public ICollection<ProjectImageGallery> ProjectImageGalleries { get; set; }
    }
}
