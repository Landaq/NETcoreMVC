using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotiationsDemo.Models
{
    public class DateRangeValidationAttribute : ValidationAttribute, IClientModelValidator
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidationAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherPropertyName);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Unknown property: {OtherPropertyName}");
            }

            var otherDate = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null) as DateTime?;

            var thisDate = value as DateTime?;

            if (thisDate.HasValue && thisDate > DateTime.Today)
            {
                return new ValidationResult("Date cannot be in the future.");
            }

            if (otherDate.HasValue && thisDate.HasValue)
            {
                if (OtherPropertyName == "FromDate" && thisDate < otherDate)
                {
                    return new ValidationResult("To date cannot be earlier than from date.");
                }
                else if (OtherPropertyName == "Todate" && thisDate > otherDate)
                {
                    return new ValidationResult("Fromm date cannot be later than to date.");
                }
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-daterange", ErrorMessage ?? "Date is out of the allowed range.");
            MergeAttribute(context.Attributes, $"data-val-daterange-other", OtherPropertyName);
        }

        private void MergeAttribute(IDictionary<string, string> attributes, string key, string value) 
        { 
            if(!attributes.ContainsKey(key))
            {
                attributes.Add(key, value);
            }
        }
    }
}
