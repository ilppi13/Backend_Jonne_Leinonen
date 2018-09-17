using System.ComponentModel.DataAnnotations;

namespace web_api
{
    public class ItemTypeValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            string itemType = value as string;

            if (itemType == "sword") {
                return ValidationResult.Success;
            } else if (itemType == "bow") {
                return ValidationResult.Success;
            } else if (itemType == "axe") {
                return ValidationResult.Success;
            } else {
                return new ValidationResult("Wrong item type");
            }
        }
    }
}