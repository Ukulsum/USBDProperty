﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public enum Interested
    {
        ZoomInterested = 1,
        Buy = 2,
        Sale = 3
    }
    public class ClientContact
    {
        [Key]
        [DisplayName("ID")]
        public int ClientContactId { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Name")]
        public string ClientName { get; set; }
        [Required]
        [DisplayName("ContactNo")]
        public string ContactNo { get; set; }
        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        //[Required]
        //[DisplayName("Purposes")] // (Sell/Buy/Rent)
        //public string PropertyForId { get; set; } 
        //[ForeignKey("PropertyType")]
        //public int PropertyTypeId { get; set; }
        public DateTime ContactDate { get; set; } =  DateTime.Now.Date;
        //[Required]
        [MaxLength]
        public string? Message { get; set; }
        public Interested Interested { get; set; }


        //public PropertyFor PropertyFor { get; set; }
        //public PropertyType PropertyType { get; set; }
    }
}
