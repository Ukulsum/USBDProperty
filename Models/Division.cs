﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USBDProperty.Models
{
    public class Division
    {
        [Key]
        [DisplayName("ID")]
        public int DivisionID { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Division")]
        public  string DivisionName { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ValidateNever]
        public Country Country { get; set; }
    }
}
