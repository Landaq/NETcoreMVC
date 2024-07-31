using FluentValidation;

namespace FluentAPIDemo.Models
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator() 
        {
            // Ensure the event date is in the future
            RuleFor(e => e.EventDate)
                .GreaterThan(DateTime.Now).WithMessage("Event Date must be in the future");

            // For demonstration, let's assume we want events only within the next 30 days
            RuleFor(e => e.EventDate)
                .LessThan(DateTime.Now.AddDays(30)).WithMessage("Event Date Must be within the next 30 days");

            // Ensure the event date is not on a weekend
            RuleFor(e => e.EventDate)
                .Must(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                .WithMessage("Events on weekends are not allowed");

            //// InclusiveBetween example, ensuring date is within a specific range
            //RuleFor(e => e.EventDate)
            //    .InclusiveBetween(DateTime.Now, DateTime.Now.AddMonths(1))
            //    .WithMessage("Event Date must be within the next month");

        }
    }
}
