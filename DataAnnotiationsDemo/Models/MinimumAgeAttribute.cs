using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotiationsDemo.Models
{
    public class MinimumAgeAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
            ErrorMessage = $"You must be at least {minimumAge} years old.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date of Birth is required.");
            }

            if (value is DateTime)
            {
                DateTime dateOfBirth = (DateTime)value;
                if (dateOfBirth > DateTime.Now.AddYears(-_minimumAge))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            else
            {
                return new ValidationResult("Invalid date format.");
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-minimumage", ErrorMessage);
            MergeAttribute(context.Attributes, "data-val-minimumage-minage", _minimumAge.ToString());
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (!attributes.ContainsKey(key))
            {
                attributes.Add(key, value);
                return true;
            }
            return false;
        }
    }
}
