using FluentValidation;

namespace FluentAPIDemo.Models
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // Validation rule for Price
            RuleFor(p => p.Price)
                .GreaterThan(10).WithMessage("Price must be greater than 10.")
                .LessThan(10000).WithMessage("Price must be less than 10000.");

            // Validation rule for Discount
            RuleFor(p => p.Discount)
                .InclusiveBetween(0, 100).WithMessage("Discount must be between 0% and 100% inclusive.");

            // Validation rule for StockCount
            RuleFor(p => p.StockCount)
                .GreaterThanOrEqualTo(0).WithMessage("Stock count should be  between 1 and 500")
                .LessThanOrEqualTo(500).WithMessage("Stock count should be between 1 and 500");

            RuleFor(p => p.Name).NotEmpty().WithMessage("Product name is required");

            RuleFor(p => p.Quantity)
                .GreaterThan(0)
                .WithMessage("Product quantity must be greater than 0.");
        }
    }
}
