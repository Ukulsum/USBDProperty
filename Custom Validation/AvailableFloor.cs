using System.ComponentModel.DataAnnotations;
using USBDProperty.Models;

namespace USBDProperty.Custom_Validation
{
    public class AvailableFloorValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (PropertyDetails)validationContext.ObjectInstance;
            if (model.FloorAvailableNo == null)  // Abort if no End Date
                return ValidationResult.Success;

            int noOFfloor = model.TotalFloor.GetValueOrDefault();
            int avFloor = int.Parse(value.ToString());  // value = StartDate

            if (avFloor > noOFfloor)

                return  new ValidationResult("The Available floor must be less than No of Floor.");
            else
                return ValidationResult.Success;
        }
    }
}
