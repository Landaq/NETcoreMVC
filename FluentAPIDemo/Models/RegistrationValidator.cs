using FluentValidation;

namespace FluentAPIDemo.Models
{
    public class RegistrationValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Username)
                .NotNull().WithMessage("Username is Required")
                .NotEmpty().WithMessage("Username cannot be Empty")
                .Length(5, 30).WithMessage("Username must be between 5 and 30 characters");

            RuleFor(r => r.Password)
                .NotNull().WithMessage("Password is Required")
                .NotEmpty().WithMessage("Password cannot be Empty")
                .Length(6, 50).WithMessage("Password must be between 6 and 50 Characters.")
                .Matches("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,})$").WithMessage("Password can only contain alphanumeric characters");

            RuleFor(r => r.ConfirmPassword)
                .Equal(r => r.Password).WithMessage("Confirm Password must match Password");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email Format")
                .NotEqual("admin@example.com").WithMessage("This Email is Not Allowed");

            RuleFor(r => r.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required if you want promotions.")
                .When(r => r.WantsPromotions); // Conditionally applies the rule if WantsPromotions is true

            RuleFor(r => r.PhoneNumber)
                .Must(p => p.StartsWith("+") && p.Length > 10)
                .WithMessage("Phone number should start with '+' and be longer than 10 digits.")
                .Unless(r => string.IsNullOrEmpty(r.PhoneNumber)); // Applies the rule unless the condition is true (i.e., phone number is empty or null)
        }
    }
}
