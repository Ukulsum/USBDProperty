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
       
        [MaxLength]
        public string? Description { get; set; }
        //[ValidateNever]       
        //[StringLength(150)]
        //[DisplayName("Property Name")]
        //public string? PropertyName { get; set; }
        //public string? PropertyName
        //{
        //    get
        //    {
        //        return this.PropertyName;
        //        //return $" {FlatSize} sqft {ConstructionStatus}   {Facing} Face {NumberOfBedrooms}Bedrooms {NumberOfBaths} Bathroom";
        //    }
        //    set
        //    {
        //        if (PropertyType.IsLand)
        //        {
        //            value = $" {LandArea} {MeasurementUnit.Name} {PropertyType.PropertyTypeName} for {PropertyFor} at {Location} ";
        //        }
        //        else
        //        {
        //            value = $" {FlatSize} sqft {ConstructionStatus}   {Facing} Face {NumberOfBedrooms}Bedrooms {NumberOfBaths} Bathroom";
        //        }
        //    }
        //}

        //public string LandInfo
        //{
        //    get
        //    {
        //        //return $" {LandArea} {MeasurementUnit.Name ?? "NA"} {PropertyType.PropertyTypeName} for {PropertyFor} at {Location} ";
        //        return $" {LandArea} {MeasurementUnit.Name} {PropertyType.PropertyTypeName} for {PropertyFor} at {Location} ";
        //    }
        //}

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [DisplayName("Construction Status")]
        public ConstructionStatus ConstructionStatus { get; set; }
    
        [DisplayName("Flat Size")]
        public int? FlatSize { get; set; } = 0;

        public float? Price { get; set; } = 0.0f;
        [DisplayName("Total Price")]
        [ValidateNever]
        public double? TotalPrice
        {
            get { return this.FlatSize * Price; }
        }

        [DisplayName("Bedrooms")]
        public int? NumberOfBedrooms { get; set; } = 0;

        [DisplayName("Baths")]
        public int? NumberOfBaths { get; set; } = 0;

        [DisplayName("Balconies")]
        public int? NumberOfBalconies { get; set; } = 0;

        [DisplayName("Garages")]
        public int? NumberOfGarages { get; set; } = 0;

        [DisplayName("Total Floor")]
        public int? TotalFloor { get; set; } = 0;

        [DisplayName("Floor Available No")]
        //[Compare("TotalFloor", ErrorMessage = "The TotalFloor and Available Floor No do not match.")]
        public int? FloorAvailableNo { get; set; } = 0;
        
        public Furnished? Furnishing { get; set; }

        public Facing? Facing { get; set; } = 0;

        [DisplayName("Land Area")]
        public int LandArea { get; set; } = 0;

        public float? LandPrice { get; set; } = 0.0f;
        [ValidateNever]
        [DisplayName("Total Land Price")]
        public double? TotalLandPrice
        {
            get { return this.LandArea * LandPrice; }
        }
        [ValidateNever]
        public string? ImagePath { get; set; }
        [NotMapped]
        [ValidateNever]
        [DisplayName("Photos")]
        public IFormFile Image { get; set; }
    
        [ForeignKey("MeasurementUnit")]
        public int MeasurementID { get; set; }
        [StringLength(255)]
        public string? Comments { get; set; }
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
        [NotMapped]
        public string PropertyForstr { get; set; }

        [ValidateNever]
        [DisplayName("Property Type")]
        public PropertyType PropertyType { get; set; }

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
