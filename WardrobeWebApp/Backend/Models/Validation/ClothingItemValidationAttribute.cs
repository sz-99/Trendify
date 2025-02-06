using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Validation
{
    public class ClothingItemValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is null)
            {
                return new ValidationResult("Value cannot be null");
            }

            return ValidationResult.Success;
        }
    }
}
