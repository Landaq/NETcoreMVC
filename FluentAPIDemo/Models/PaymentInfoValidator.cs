using FluentValidation;

namespace FluentAPIDemo.Models
{
    public class PaymentInfoValidator : AbstractValidator<PaymentInfo>
    {
        public PaymentInfoValidator() 
        {
            // EmailAddress : Ensures that the string is a valid email address format
            RuleFor(p => p.BillingEmail)
                .EmailAddress().WithMessage("Please enter a valid email address.");

            // CreditCard : Validates the string as a credit card number.
            RuleFor(p => p.CardNumber)
                .CreditCard()
                .WithMessage("Please enter a valid credit card number");

            //PrecisionScale: Checks the number of allowable decimal places and the overall precision of a number.
            RuleFor(p => p.Amount)
                .PrecisionScale(8, 2, true)
                .WithMessage("Amount can have up to 2 decimal places and up to 8 total digits.");

            // Matches: Ensure the property matches a specified regex pattern.
            // We want the CardHolderName to only contain letters and spaces:
            RuleFor(p => p.CardHolderName).Matches(@"^[a-zA-Z\s]+$").WithMessage("Name can only contain letters and spaces.");
        }
        
        
    }
}
