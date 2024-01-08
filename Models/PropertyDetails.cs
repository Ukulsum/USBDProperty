using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USBDProperty.DTO;

namespace USBDProperty.Models
{
  public  enum PropertyCondition
    {
        New=1,Used
    }
    public class PropertyDetails : BaseDTO
    {
        [Key]
        [DisplayName("ID")]
        public int PropertyInfoId { get; set; }
        //[ValidateNever]
        //public IFormFile Image { get;set; }
        //public string Path { get; set; } = "";
        [StringLength(255)]
        public string Title { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        [Required]
        [StringLength(150)]
        [DisplayName("Property Name")]
        public string PropertyName { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        [StringLength(150)]
        [DisplayName("Construction Status")]
        public string ConstructionStatus { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Property Size")]
        public string PropertySize { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Bedrooms")]
        public string NumberOfBedrooms { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Baths")]
        public string NumberOfBaths { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Balconies")]
        public string NumberOfBalconies { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Garages")]
        public string NumberOfGarages { get; set; }
        [StringLength(50)]
        [DisplayName("Total Floor")]
        public string TotalFloor { get; set; }
        [StringLength(50)]
        [DisplayName("Floor Available No")]
        public string FloorAvailableNo { get; set; }
        [StringLength(150)]
        public string Furnishing { get; set; }
        [StringLength(150)]
        public string Facing { get; set; }
        [StringLength(150)]
        [DisplayName("Land Area")]
        public string LandArea { get; set; }
        [StringLength(100)]
        public string Price { get; set; }
        [ValidateNever]
        public string Path { get; set; }
        [NotMapped]
        [ValidateNever]
        [DisplayName("Photos")]
        public IFormFile Image { get; set; }
        [StringLength(100)]
        public string Measurement { get; set; }
        [StringLength(255)]
        public string Comments { get; set; }
        [DisplayName("Propety Condition")]
        public PropertyCondition PropertyCondition { get; set; }
        [DisplayName("Handover Date")]
        [DataType(DataType.Date)]
        public DateTime? HandOverDate { get; set; }
        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
       
        [ForeignKey("PropertyOwnerInfo")]
        [DisplayName("Developer/Agent")]
        public int OwnerId { get; set; }
       
        [ForeignKey("Area")]
        public int AreaId { get; set; }
         
       public PropertyFor propertyFor { get; set; }
        [ValidateNever]
        [DisplayName("Property Type")]
        public PropertyType PropertyType { get; set; }
        //[ValidateNever]   
        //public  DevelopersorAgent PropertyOwnerInfo { get; set; }

        [ValidateNever]
        public ProjectsInfo ProjectsInfo { get; set; }
        [ValidateNever]
        public Area Area { get; set; }
    }
    public enum PropertyFor
    {
        Buy=1,Sell,Rent
    }
}
