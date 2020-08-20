using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Extensions
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.Now < Convert.ToDateTime(value))
            {
                return new ValidationResult("Release date must be in the past.");
            }
            return ValidationResult.Success;
        }
    }
}