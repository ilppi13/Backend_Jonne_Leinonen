using System;
using System.ComponentModel.DataAnnotations;

namespace web_api
{
    public class DateTypeValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            DateTime time = (DateTime)value;

            if (time < System.DateTime.Now) {
                return ValidationResult.Success;
            } 
                return new ValidationResult("Wrong time, stop move time");
            }
        }
    }
