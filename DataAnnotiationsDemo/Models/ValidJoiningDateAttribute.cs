using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotiationsDemo.Models
{
    public class ValidJoiningDateAttribute : ValidationAttribute, IClientModelValidator
    {
        public ValidJoiningDateAttribute() 
        {
            ErrorMessage = "The joining date cannot be in the future.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                DateTime joiningDate = (DateTime)value;
                if (joiningDate > DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage);
                }
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
            MergeAttribute(context.Attributes, "data-val-ValidJoiningDate", ErrorMessage);
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
