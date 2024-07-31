using FluentValidation;

namespace FluentAPIDemo.Models
{
    public class CartValidator : AbstractValidator<Cart>
    {
        public CartValidator() 
        {
            RuleFor(c => c.Products)
                .NotEmpty()
                .WithMessage("Cart must contain at least one product.");

            RuleForEach(c => c.Products).SetValidator(new ProductValidator());

            RuleFor(c => c.Products)
                .Must(ContainUniqueProducts)
                .WithMessage("Products in the cart must be unique.");
        }

        private bool ContainUniqueProducts(List<Product> products)
        {
            var uniqueProductNames = new HashSet<string>();
            foreach (var product in products)
            {
                if (!uniqueProductNames.Add(product.Name))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
