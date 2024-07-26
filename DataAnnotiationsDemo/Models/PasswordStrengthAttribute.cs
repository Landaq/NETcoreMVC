using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DataAnnotiationsDemo.Models
{
    public class PasswordStrengthAttribute : ValidationAttribute, IClientModelValidator
    {
        public PasswordStrengthAttribute() 
        {
            ErrorMessage = @"Password must contain at least one uppercase letter,
                            one lowercase letter, one number, one special character (@,#,$,&) 
                            and be at least 8 characters long.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Password is required.");
            }

            var password = value.ToString();
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$&])[A-Za-z\d@#$&]{8,}$");

            if (!regex.IsMatch(password))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-passwordstrength", ErrorMessage);
        }
    }
}
