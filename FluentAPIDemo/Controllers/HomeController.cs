using FluentAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAPIDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult ProcessPayment()
        {
            return View();
        }

        public IActionResult ScheduleEvent()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            Cart cart = new Cart();
            List<Product> products = new List<Product>()
            {
                new Product(){Name = "Product1", Quantity=1},
                new Product(){Name = "Product2", Quantity=2},
                new Product(){Name = "Product2", Quantity=5},
                new Product(){Name = "Product3", Quantity=0}
            };
            cart.Products = products;
            return View(cart);
        }

        [HttpPost]
        public IActionResult Checkout(Cart cart)
        {
            if(!ModelState.IsValid)
            {
                return View(cart);
            }
            return RedirectToAction("Success");
        }


        [HttpPost]
        public IActionResult ScheduleEvent(Event eventModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventModel); // Return with validation errors.
            }
            return RedirectToAction("Success");
        }

        [HttpPost]
        public IActionResult ProcessPayment(PaymentInfo paymentInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(paymentInfo);
            }

            return RedirectToAction("Success");
        }
        [HttpPost]
        public IActionResult AddProduct(Product product) 
        {
            if (!ModelState.IsValid) 
            {
                return View(product);
            }

            return RedirectToAction("Success");
        }

        [HttpPost]
        public IActionResult Register(RegistrationModel model)
        {
            //RegistrationValidator validator = new RegistrationValidator();
            //var validationResult = validator.Validate(model);

            //if (!validationResult.IsValid)
            //{
            //    return View(model);               
            //}

            if (!ModelState.IsValid)
            {
                // Validation failed, return to the form with errors
                return View(model);
            }

            // Handle successful validation logic here
            return RedirectToAction("Success");
        }

        public string Success()
        {
            return "Registration Successful";
        }

    }
}
