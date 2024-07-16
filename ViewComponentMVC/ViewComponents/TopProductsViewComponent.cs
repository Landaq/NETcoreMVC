using Microsoft.AspNetCore.Mvc;
using ViewComponentMVC.Models;

namespace ViewComponentMVC.ViewComponents
{
    public class TopProductsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            // Your logic for preparing data
            ProductRepository productRepository = new ProductRepository();
            var products = await productRepository.GetTopProductsAsync(count);
            return View(products);
        }
        
    }
}
