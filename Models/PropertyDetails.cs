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
    public enum Facing
    {
        South = 1, North,East,West,NotApplicable
    }
    public enum Furnished
    {
      Furnished=1,  Semi_Furnished  , Un_Furnished
    }
    public enum ConstructionStatus
    {
        Ready = 1, UpComing, UnderConstruction, UnderDevelopment, AlmostReady, Upcoming, Used
    }
    public class PropertyDetails : BaseDTO
    {
        [Key]
        [DisplayName("ID")]
        public int PropertyInfoId { get; set; }
        [ValidateNever]
        public bool ISFeatured { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
       
        [ValidateNever]
        public double TotalPrice
        {
            get { return this.PropertySize* Price; }
        }
        [MaxLength]
        public string? Description { get; set; }
        [ValidateNever]       
        //[StringLength(150)]
        [DisplayName("Property Name")]
        //public string PropertyName { get; set; }
        public string PropertyName
        {
            get
            {
                return $" {PropertySize} sqft {ConstructionStatus}   {Facing} Face {NumberOfBedrooms}Bedrooms {NumberOfBaths} Bathroom";
            }
        }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }
       
        [DisplayName("Construction Status")]
        public ConstructionStatus ConstructionStatus { get; set; }
        [Required]
    
        [DisplayName("Property Size")]
        public int PropertySize { get; set; }
        [Required]
        
        [DisplayName("Bedrooms")]
        public int NumberOfBedrooms { get; set; }
        [Required]
        
        [DisplayName("Baths")]
        public int NumberOfBaths { get; set; }
        [Required]
        
        [DisplayName("Balconies")]
        public int NumberOfBalconies { get; set; }
        [Required]
        
        [DisplayName("Garages")]
        public int NumberOfGarages { get; set; }
        
        [DisplayName("Total Floor")]
        public int TotalFloor { get; set; }
        
        [DisplayName("Floor Available No")]
        public int FloorAvailableNo { get; set; }
        
        public Furnished Furnishing { get; set; }
        
        public Facing Facing { get; set; }
        
        [DisplayName("Land Area")]
        public int LandArea { get; set; }
        
        public float Price { get; set; }
        [ValidateNever]
        public string? ImagePath { get; set; }
        [NotMapped]
        [ValidateNever]
        [DisplayName("Photos")]
        public IFormFile Image { get; set; }
    
        [ForeignKey("MeasurementUnit")]
        public int MeasurementID { get; set; }
        [StringLength(255)]
        public string Comments { get; set; }
        [DisplayName("Propety Condition")]
        public PropertyCondition PropertyCondition { get; set; }
        [DisplayName("Handover Date")]
        [DataType(DataType.Date)]
        public DateTime? HandOverDate { get; set; }
        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
       
        [ForeignKey("ProjectsInfo")]
        [DisplayName("Project")]
        public int ProjectId { get; set; }
       
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        //[ForeignKey("propertyFor")]
        //public int PropertyForId { get; set; }


        //[ValidateNever]
        //[DisplayName("Property For")]
        //public PropertyFor propertyFor { get; set; }
        [ValidateNever]
        [DisplayName("Property Type")]
        public PropertyType PropertyType { get; set; }
        //[ValidateNever]   
        //public  DevelopersorAgent PropertyOwnerInfo { get; set; }

        [ValidateNever]
        public ProjectsInfo ProjectsInfo { get; set; }
        [ValidateNever]
        public Area Area { get; set; }
        public PropertyFor PropertyFor { get; set; }
        [ValidateNever]
        public MeasurementUnit MeasurementUnit { get; set; }
    }
    public enum PropertyFor
    {
        Buy=1,Sale,Rent
    }
}
