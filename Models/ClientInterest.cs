using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class ClientInterest
    {
        public int ID { get; set; }
        [ForeignKey("Client")]
        public int ClientID { get; set; }
        [ForeignKey("Property")]
        public int PropertyID { get; set; }
        [Required]
        [DisplayName("Purposes")] // (Sell/Buy/Rent)
        [ForeignKey("PropertyFor")]
        public int PropertyForId { get; set; }
        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
        [Required]
        [MaxLength]
        public string Message { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual PropertyFor PropertyFor { get; set; }
        public virtual ClientContact Client { get; set; }
        public virtual PropertyDetails Property { get; set; }

    }
}
