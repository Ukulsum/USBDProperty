using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USBDProperty.DTO;

namespace USBDProperty.Models
{
    public class PropertyDetails : BaseDTO
    {
        [Key]
        public int PropertyInfoId { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [MaxLength]
        public string Description { get; set; }
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
        [DisplayName("Number Of Bedrooms")]
        public string NumberOfBedrooms { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Number Of Baths")]
        public string NumberOfBaths { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Number Of Balconies")]
        public string NumberOfBalconies { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Number Of Garages")]
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
        [StringLength(100)]
        public string Measurement { get; set; }
        [StringLength(255)]
        public string Comments { get; set; }
        [DisplayName("Handover Date")]
        public DateTime? HandOverDate { get; set; }
        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }
        [ForeignKey("PropertyOwnerInfo")]
        public int OwnerId { get; set; }
        [ForeignKey("SocialIcon")]
        public int IconId { get; set; }
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        [ForeignKey("propertyFor")]
        public int PropertyForId { get; set; }


        public PropertyFor propertyFor { get; set; }
        public PropertyType PropertyType { get; set; }
        public TransactionType TransactionType { get; set; }
        public  PropertyOwnerInfo PropertyOwnerInfo { get; set; }
        public SocialIcon SocialIcon { get; set; }
        public Area Area { get; set; }
    }
}
